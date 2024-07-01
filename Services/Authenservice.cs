using Microsoft.AspNetCore.Mvc;

namespace AQapi.Services
{
    public interface IAuthService
    {
        bool ValidateAdmin(ControllerBase controller);
    }

    public class Authentication : IAuthService
    {
        public bool ValidateAdmin(ControllerBase controller)
        {
            // Authentication logic
            var (userId, username) = controller.GetSessionUserInfo();
            return userId != null && username == "admin";
        }

    }
}
