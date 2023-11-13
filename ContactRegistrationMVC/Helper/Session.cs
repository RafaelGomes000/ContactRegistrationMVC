using ContactRegistrationMVC.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ContactRegistrationMVC.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreateUserSession(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("loggedUserSession", value);
        }

        public UserModel FindUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("loggedUserSession");

            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("loggedUserSession");
        }
    }
}
