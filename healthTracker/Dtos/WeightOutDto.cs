using healthTracker.Models.Enums;

namespace healthTracker.Dtos
{
    public class WeightOutDto : IBaseOutDto
    {
        public int UserId { get; set; }
        public double Poundage { get; set; }
        public DateTime Date { get; set; }
        public UnitsEnum Units { get; set; }
    } 
}
