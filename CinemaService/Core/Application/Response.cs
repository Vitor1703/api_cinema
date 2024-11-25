namespace Application
{
    public enum ErrorCode
    {
        NOT_FOUND = 1,
        MISSING_REQUIRED_INFORMATION = 2,
    }
    public abstract class Response
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public ErrorCode ErrorCode { get; set; }

    }
}
