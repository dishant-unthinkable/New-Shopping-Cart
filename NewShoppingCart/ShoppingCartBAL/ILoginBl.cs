using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBALObject;
namespace ShoppingCartBAL
{
    public interface ILoginBl
    {
        void AddUser(LoginObject loginObject);
        int AuthenticateUser(LoginObject loginObject);
        string GetRole(LoginObject loginObject);
        int GoogleAuthentication(LoginObject loginObject);
    }
}
