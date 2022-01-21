using ShoppingCartBALObject;
using ShoppingCartBAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ShoppingCart.Controllers
{
  
    public class AccountController : Controller
    {
        private readonly ILoginObject _loginObject;
        private readonly ILoginBl _loginBl;
        public AccountController(ILoginObject loginObject, ILoginBl loginBl )
        {
            _loginObject = loginObject;
            _loginBl = loginBl;
        }
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginObject loginObject)
        {
            _loginObject.email = loginObject.email;
            _loginObject.password = loginObject.password;
            bool access = _loginBl.AuthenticateUser((LoginObject)_loginObject);
            string role = _loginBl.GetRole((LoginObject)_loginObject);
            if (access)
            {

                if (role=="Admin")
                    return RedirectToRoute("newRoute");
                else
                {
                    return RedirectToRoute("newRoute");
                }
                
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View();
            }
        }

        public ActionResult SignUp()
        {
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
    }
}
