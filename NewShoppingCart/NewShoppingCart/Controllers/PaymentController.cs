using Microsoft.AspNetCore.Mvc;
using NewShoppingCart.Models;
using System.Text;
using System;
using System.Security.Cryptography;
using System.Net;
using System.Diagnostics;
using ShoppingCartBAL;
using ShoppingCartBALObject;

namespace NewShoppingCart.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IProductBl _productBl;
        public PaymentController(IProductBl productBl)
        {
            _productBl = productBl;
        }
        public IActionResult Index(int UserId, int Amount)
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            Payment payment = new Payment();
            payment.UserId = UserId;
            payment.Amount = Amount;
            return View(payment);
        }

        public ActionResult CreateOrder(Payment payment)
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            // Generate random receipt number for order
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_cEPU4HG6E0XKkp", "yxEdPIBtSbfhPtK8chx6UiOu");
            Dictionary<string, object> opt = new Dictionary<string, object>();
            opt.Add("amount", payment.Amount * 100);  // Amount will in paise
            opt.Add("receipt", transactionId);
            opt.Add("currency", "INR");
            opt.Add("payment_capture", "0"); // 1 - automatic  , 2 - manual
                                             //options.Add("notes", "-- You can put any notes here --");                                  
            try
            {
                Razorpay.Api.Order orderResponse = client.Order.Create(opt);


                string orderId = orderResponse["id"].ToString();

                // Create order model for return on view
                OrderModel orderModel = new OrderModel
                {
                    UserId = payment.UserId,
                    orderId = orderResponse.Attributes["id"],
                    //orderId = orderId,
                    razorpayKey = "rzp_test_cEPU4HG6E0XKkp",
                    amount = payment.Amount * 100,
                    currency = "INR",
                    name = payment.Name,
                    email = payment.Email,
                    contactNumber = payment.ContactNumber,
                    address = payment.Address,
                    description = "Testing description"
                };

                // Return on PaymentPage with Order data
                return View("PaymentPage", orderModel);
            }
            catch (Exception)
            {
                ViewBag.Message = "OOPs!! May be your Connection interupted";
                return View("/Views/Home/Error.cshtml");
            }
        }
        /*[HttpPost]
        [Obsolete]
        public void Index(IFormCollection form, WebClient request)
        {
            string UserId = form["UserId"].ToString().ToString();
            string firstName = form["FirstName"].ToString();
            string amount = form["Amount"].ToString();
            string phone = form["Phone"].ToString();
            string surl = "http://localhost:7183/PaymentStatus/Index";
            string furl = "http://localhost:7183/PaymentStatus/Index";


            RemotePost myremotepost = new RemotePost();

            string key = "wic3OI";

            string salt = "Xf2qB0Xd5YqtHblJAmuKGW9nR3IBMRS8";

            myremotepost.Url = "https://sandboxsecure.payu.in/_payment";
            myremotepost.Add("key", "4ptctt6n");
            string txnid = Generatetxnid();
            myremotepost.Add("txnid", txnid);
            myremotepost.Add("amount", amount);

            myremotepost.Add("firstname", firstName);
            myremotepost.Add("phone", phone);

            myremotepost.Add("surl", surl);//Change the success url here depending upon the port number of your local system.  
            myremotepost.Add("furl", furl);//Change the failure url here depending upon the port number of your local system.  
            myremotepost.Add("service_provider", "payu_paisa");
            string hashString = key + "|" + txnid + "|" + amount + "|" + firstName + "|||||||||||" + salt;
            string hash = Generatehash512(hashString);
            myremotepost.Add("hash", hash);

            request = myremotepost.Post(new NoRedirectWebClient());
            var psi = new ProcessStartInfo(@"C:\Program Files\Google\Chrome\Application\chrome.exe");

            psi.Arguments = request.ResponseHeaders["https://sandboxsecure.payu.in/_payment"];
            Process.Start(psi);
        }
        [Obsolete]
        public class NoRedirectWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                var temp = base.GetWebRequest(address) as HttpWebRequest;
                temp.AllowAutoRedirect = false;
                return temp;
            }
        }
        private string Generatetxnid()
        {
            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);

            return txnid1;
        }

        private string Generatehash512(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);

            //UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
        public class RemotePost
        {
            private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();


            public string Url = "";
            public string Method = "post";
            public string FormName = "form1";

            public void Add(string name, string value)
            {
                Inputs.Add(name, value);
            }

            public WebClient Post(WebClient webClient)
            {
                System.Web.HttpContext.Current.Response.Clear();

                System.Web.HttpContext.Current.Response.Write("<html><head>");

                System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
                System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
                for (int i = 0; i < Inputs.Keys.Count; i++)
                {
                    System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
                }
                System.Web.HttpContext.Current.Response.Write("</form>");
                System.Web.HttpContext.Current.Response.Write("</body></html>");

                System.Web.HttpContext.Current.Response.End();
                webClient.UploadValues(Url, "POST", Inputs);

                return webClient;
            }
        }*/
        public class OrderModel
        {
            public int UserId { get; set; }
            public string? orderId { get; set; }
            public string? razorpayKey { get; set; }
            public int amount { get; set; }
            public string? currency { get; set; }
            public string? name { get; set; }
            public string? email { get; set; }
            public string? contactNumber { get; set; }
            public string? address { get; set; }
            public string? description { get; set; }
        }
        
        [HttpPost]
        public ActionResult Complete(IFormCollection form)
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            // Payment data comes in url so we have to get it from url

            // This id is razorpay unique payment id which can be use to get the payment details from razorpay server
            //string paymentId = Request.Params["rzp_paymentid"];
            string paymentId = form["rzp_paymentid"];
            int UserId = Convert.ToInt32(form["UserId"]);
            // This is orderId
            //string orderId = Request.Params["rzp_orderid"];
            string orderId = form["rzp_orderid"];

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_cEPU4HG6E0XKkp", "yxEdPIBtSbfhPtK8chx6UiOu"); ;

            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

            // This code is for capture the payment 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];

            //// Check payment made successfully

            if (paymentCaptured.Attributes["status"] == "captured")
            {
                OrderInfoObject orderInfo = new OrderInfoObject
                {
                    OrderId = orderId,
                    UserId = UserId,
                    Amount = paymentCaptured.Attributes["amount"] / 100,
                    Method = paymentCaptured.Attributes["method"],
                    Email = paymentCaptured.Attributes["email"],
                    Contact = paymentCaptured.Attributes["contact"],
                    BankTransactionID = paymentCaptured.Attributes["acquirer_data"].bank_transaction_id,
                    Address = paymentCaptured.Attributes["notes"].address
                };
                _productBl.OrderedProducts(UserId, orderId);
                _productBl.PaymentInfo(orderInfo);
                _productBl.DeleteFromCart(UserId, 0);
                // Create these action method
                return RedirectToAction("Success", "PaymentStatus");
            }
            else
            {
                return RedirectToAction("Failed", "PaymentStatus");
            }
        }
    }

    
}
