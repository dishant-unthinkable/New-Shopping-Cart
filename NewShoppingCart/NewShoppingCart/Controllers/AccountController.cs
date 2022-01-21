using ShoppingCartBALObject;
using ShoppingCartBAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace NewShoppingCart.Controllers
{
  
    public class AccountController : Controller, IAccountController
    {
        public int _userId { get; set; }
        private readonly ILoginObject _loginObject;
        private readonly ILoginBl _loginBl;
        
        public AccountController(ILoginObject loginObject, ILoginBl loginBl )
        {
            _loginObject = loginObject;
            _loginBl = loginBl;
            //_userId = loginObject.UserID;
        }
        public ActionResult Login()
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            return View();
        }
        public ActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme); 
        }

        public async Task<ActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            try
            {
                var claims = result.Principal.Identities.FirstOrDefault()
                    .Claims.Select(claim => new
                    {
                        claim.Issuer,
                        claim.OriginalIssuer,
                        claim.Type,
                        claim.Value
                    });

                _loginObject.email = claims.Last().Value;
                _loginObject.password = null;
                int userId = _loginBl.GoogleAuthentication((LoginObject)_loginObject);

                TempData["userId"] = userId;
                TempData["usermail"] = claims.Last().Value;
                return RedirectToAction("User", "Home");
            }
            catch (Exception)
            {
                ViewBag.Message = "Provided Google Account Information is Null";
                return View("/Views/Home/Error.cshtml");
            }
        }
        public ActionResult Logout()
        {
            TempData["userId"] = 0;
            TempData["usermail"] = null;
            return Login(null);
        }
        [HttpPost]
        public ActionResult Login(LoginObject? loginObject)
        {
            if (loginObject == null)
            {
                return RedirectToAction("Login");
            }
            _loginObject.email = loginObject.email;
            _loginObject.password = loginObject.password;
            int userId = _loginBl.AuthenticateUser((LoginObject)_loginObject);
            string role = _loginBl.GetRole((LoginObject)_loginObject);
            //Console.Write(loginObject.UserID);
            //_userId = 2;
            //ViewBag.userId = 5;
            //getUserId(loginObject);
            TempData["userId"] = userId;
            TempData["usermail"] = loginObject.email;

            if (userId!=0)
            {

                if (role=="Admin")
                    return RedirectToAction("Index", "Home");
                return RedirectToAction("User", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View();
            }
        }

        public ActionResult SignUp()
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(LoginObject loginObject)
        {
            _loginObject.email = loginObject.email;
            _loginObject.password = loginObject.password;
            _loginBl.AddUser((LoginObject)_loginObject);
            return RedirectToAction("Login");
        }

        /*public int getUserId(LoginObject loginObject)
        {
            return loginObject.UserID;
        }*/
    }
    
}
