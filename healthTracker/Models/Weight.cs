using healthTracker.Dtos;
using healthTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace healthTracker.Models
{
    public class Weight : IBaseClass
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public double Poundage { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public UnitsEnum Units { get; set; }

        public override IBaseOutDto ConvertToDto()
        {
            WeightOutDto dto = new()
            {
                Id = Id,
                UserId = UserId,
                Poundage = Poundage,
                DateCreated = DateCreated,
                Date = Date,
                DateUpdated = DateUpdated,
                Units = Units
            };
            return dto;
        }
    }
}
