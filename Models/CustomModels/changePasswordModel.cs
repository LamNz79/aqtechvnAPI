namespace AQapi.Models.CustomModels
{
    public class changePasswordModel
    {
        public long Id { get; set; }
        public string Password { get; set; } = null!;
        public string? OldPass { get; set; }
    }
}