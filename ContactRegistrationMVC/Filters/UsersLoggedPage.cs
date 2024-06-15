using ContactRegistrationMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ContactRegistrationMVC.Filters
{
    public class UsersLoggedPage : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("UserLoggedSession");
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
            if (string.IsNullOrEmpty(userSession) || user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "login"}, {"action", "index"} });
            }

            base.OnActionExecuting(context);
        }
    }
}
