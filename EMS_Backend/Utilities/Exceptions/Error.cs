namespace Utilities.Exceptions
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;

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
    }
}
