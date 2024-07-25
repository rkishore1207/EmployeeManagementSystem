namespace BusinessLogics.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid UID { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
    }
}
