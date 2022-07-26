namespace healthTracker.Config
{
    public class HealthTrackerOptions 
    {
        public const string ConfigName = "HealthTrackerOptions";
        public string Version { get; set; } = String.Empty;
        public string? FrontEndWebApp { get; set; }
        public string Environment { get; set; } = String.Empty;
        public string Github { get; set; } = String.Empty;
    }
}
