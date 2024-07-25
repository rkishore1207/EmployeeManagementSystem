namespace DataAccessLayer.Models
{
    public class UserEntity
    {
        public static readonly UserEntity Instance = new UserEntity() { FirstName = "Unknown", EmployeeID = "0000", Email = "example.com" };
        public Guid UID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmployeeID { get; set; }
        public string? UserRole { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string? Location { get; set; }
        public string? MaritalStatus { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? BloodGroup { get; set; }
        public string? EmergencyNumber { get; set; }
        public string? About { get; set; }
        public string? School { get; set; }
        public string? College { get; set; }
        public string? PreviousCompany { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? HashKey { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime ResetPasswordTokenExpiry { get; set; }
    }
}
