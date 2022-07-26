using healthTracker.Dtos;
using System.ComponentModel.DataAnnotations;

namespace healthTracker.Models
{
    public class BodyFat : IBaseClass
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public double BodyFatPercentage { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public override IBaseOutDto ConvertToDto()
        {
            BodyFatOutDto dto = new()
            {
                Id = Id,
                UserId = UserId,
                BodyFatPercentage = BodyFatPercentage,
                Date = Date,
                DateCreated = DateCreated,
                DateUpdated = DateUpdated,
            };
            return dto;
        }
    }
}
