namespace GDS.Api.Model.Response
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ExceptionType { get; set; } = string.Empty;
        public Exception? Exception { get; set; } = null;
    }
}
