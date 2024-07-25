namespace BusinessLogics.Models.RequestModels
{
    public class UserRegisterRequest
    {
        public Guid UID { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string EmployeeID { get; set; }
        public string? Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
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
    }
}
