namespace healthTracker.Dtos
{
    public class BodyFatOutDto : IBaseOutDto
    {
        public int UserId { get; set; }
        public double BodyFatPercentage { get; set; }
        public DateTime Date { get; set; }
    }
}
