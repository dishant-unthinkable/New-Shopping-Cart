using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBALObject;
using ShoppingCartDAL;
using System.Web.Security;

namespace ShoppingCartBAL
{
    public class LoginBL:ILoginBl
    {
        private readonly IProductDataAccess _productDataAccess;
        public LoginBL(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }
        public void AddUser(LoginObject loginObject)
        {
           
            _productDataAccess.AddUser(loginObject);
        }

        public int AuthenticateUser(LoginObject loginObject)
        {
            return _productDataAccess.AuthenticateUser(loginObject);
        }

        public string GetRole(LoginObject loginObject)
        {
            return _productDataAccess.GetRole(loginObject);
        }

        public int GoogleAuthentication(LoginObject loginObject)
        {
            return _productDataAccess.GoogleAuthentication(loginObject);
        }
    }
}
