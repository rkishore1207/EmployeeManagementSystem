namespace Utilities.Exceptions
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Property { get; set; } = string.Empty;

        public Error() 
        {
            Code = 0;
        }

        public Error(string message) : this()
        {
            Message = message;
        }

        public Error(string message, int code) : this(message)
        {
            Code = code;
        }

        public Error(int code, string message, string property) : this(message,code)
        {
            Property = property;
        }
    }
}
