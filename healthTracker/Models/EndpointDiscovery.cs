namespace healthTracker.Models
{
    public class EndpointDiscovery
    {
        public string Url { get; set; } = string.Empty;
        public string RequestType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string InputFormat { get; set; } = string.Empty; 
        public string OutputFormat { get; set; } = string.Empty;
    }
}
