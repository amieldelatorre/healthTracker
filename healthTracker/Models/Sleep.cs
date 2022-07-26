using healthTracker.Dtos;
using System.ComponentModel.DataAnnotations;

namespace healthTracker.Models
{
    public class Sleep : IBaseClass
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public double HoursSlept { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }

        public override IBaseOutDto ConvertToDto()
        {
            SleepOutDto dto = new()
            {
                Id = Id,
                UserId = UserId,
                HoursSlept = HoursSlept,
                StartTime = StartTime,
                EndTime = EndTime,
                Date = Date,
                DateCreated = DateCreated,
                DateUpdated = DateUpdated,
            };
            return dto;
        }
    }
}
