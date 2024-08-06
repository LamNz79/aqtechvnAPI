namespace AQapiDev.Models.CustomModels
{
    public class LoginModel
    {
        public long Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginWithEmailModel
    {
        public long Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
    }
    public class UserAndVerificationCodeModel
    {

        public string Username { get; set; }
        public string Code { get; set; }
        public string newPassword { get; set; }
    }
}