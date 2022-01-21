using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NewShoppingCart.Models
{
    public class CustomFilter: Attribute
    {
        //private readonly IAuthorizationService _authorizeService;
        //private readonly int _userId;
        public CustomFilter()
        {
            Console.Write("hello");
        }
        /*public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();
            
            if (userId != null)
            {
                var result = _authorizeService.CanManageUser(userId);
                if (!result)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "Account" },
                                          { "action", "Login" }

                                         });
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "Account" },
                                          { "action", "Login" }

                                         });

            }
            base.OnActionExecuting(filterContext);
        }*/
    }
}
