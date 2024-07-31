namespace Utilities.Constants
{
    public static class Constant
    {
        public static class CustomExceptions
        {
            public const string InvalidUser = "User Data is not Sufficient";
            public const string DuplicateUser = "User already Exists"; //1001
            public const string CustomExceptionMessage = "Something went Wrong";
            public const string UnAuthorizedException = "Access Restricted";
            public const string InValidEmail = "User Does Not Exist"; //1004
            public const string InCorrectPassword = "InCorrect Password"; //1002
            public const string Forbidden = "Forbidden";
            public const string NoUsersWereRegistered = "No Users were Registered"; //1003
        }

        public static class Email
        {
            public const string EmailSubject = "Reset Password";
        }
    }
}
