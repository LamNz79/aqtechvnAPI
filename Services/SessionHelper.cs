using Microsoft.AspNetCore.Mvc;

namespace AQapi.Services
{
    public static class SessionHelper
    {
        public static (string UserId, string Username) GetSessionUserInfo(this ControllerBase controller)
        {
            var userId = controller.HttpContext.Session.GetString("UserId");
            var username = controller.HttpContext.Session.GetString("Username");
            return (userId, username);
        }
    }
}
