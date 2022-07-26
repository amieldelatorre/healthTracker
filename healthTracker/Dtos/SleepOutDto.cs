namespace healthTracker.Dtos
{
    public class SleepOutDto : IBaseOutDto
    {
        public int UserId { get; set; }
        public double HoursSlept { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        
    }
}
