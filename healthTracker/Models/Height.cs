using healthTracker.Dtos;
using healthTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace healthTracker.Models
{
    public class Height : IBaseClass
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Elevation { get; set; }
        [Required]
        public UnitsEnum Units { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public override IBaseOutDto ConvertToDto()
        {
            HeightOutDto dto = new()
            {
                Id = Id,
                UserId = UserId,
                Elevation = Elevation,
                Units = Units,
                Date = Date,
                DateCreated = DateCreated,
                DateUpdated = DateUpdated,
            };

            return dto;
        }
    }
}
