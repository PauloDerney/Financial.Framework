namespace Financial.Framework.Domain.Responses
{
    public class ResponseBase
    {
        public ResponseBase(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ResponseBase()
        {
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
