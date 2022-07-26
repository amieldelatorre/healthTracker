namespace healthTracker.Dtos
{
    public class SleepInDto
    {
        public int UserId { get; set; }
        public Double HoursSlept { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
    }
}
