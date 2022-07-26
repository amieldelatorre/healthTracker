using healthTracker.Models.Enums;

namespace healthTracker.Dtos
{
    public class WeightInDto
    {
        public int UserId { get; set; }
        public double Poundage { get; set; }
        public DateTime Date { get; set; }
        public UnitsEnum Units { get; set; }
    }
}
