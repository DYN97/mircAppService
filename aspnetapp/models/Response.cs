namespace aspnetapp.models
{
    public class Response
    {
        public object? Data { get; set; }
        public int Code { get; set; } = 0;
        public string? Message { get; set; }

    }
}
