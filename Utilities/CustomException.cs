namespace utilities
{
    public class CustomException : Exception
    {
        public string? ErrorCode { get; private set; }

        public CustomException() { }

        public CustomException(string message)
            : base(message) { }

        public CustomException(string message, Exception inner)
            : base(message, inner) { }

        public CustomException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
