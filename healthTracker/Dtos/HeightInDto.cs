using healthTracker.Models.Enums;

namespace healthTracker.Dtos
{
    public class HeightInDto
    {
        public int UserId { get; set; }
        public int Elevation { get; set; }
        public DateTime Date { get; set; }
        public UnitsEnum Units { get; set; }
    }
}
