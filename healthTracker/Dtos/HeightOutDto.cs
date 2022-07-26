using healthTracker.Models.Enums;

namespace healthTracker.Dtos
{
    public class HeightOutDto : IBaseOutDto
    {
        public int UserId { get; set; }
        public int Elevation { get; set; }
        public UnitsEnum Units { get; set; }
        public DateTime Date { get; set; }
    }
}
