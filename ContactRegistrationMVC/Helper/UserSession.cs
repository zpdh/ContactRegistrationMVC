using ContactRegistrationMVC.Models;
using Newtonsoft.Json;

namespace ContactRegistrationMVC.Helper
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserSession(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void StartSession(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("UserLoggedSession", value);
        }

        public void EndSession()
        {
            _httpContext.HttpContext.Session.Remove("UserLoggedSession");
        }

        public UserModel FindSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("UserLoggedSession");
            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }

    }
}
