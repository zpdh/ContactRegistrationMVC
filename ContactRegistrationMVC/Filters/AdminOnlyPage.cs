using ContactRegistrationMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ContactRegistrationMVC.Enums;

namespace ContactRegistrationMVC.Filters
{
    public class AdminOnlyPage : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("UserLoggedSession");
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

            if (string.IsNullOrEmpty(userSession) || user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login"}, {"action", "Index"} });
            }
            if ((user.UserType != UserTypeEnum.Admin))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restricted" }, { "action", "Index" } });
            }

            base.OnActionExecuting(context);
        }
    }
}
