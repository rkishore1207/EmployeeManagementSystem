namespace BusinessLogics.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid UID { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
    }
}
