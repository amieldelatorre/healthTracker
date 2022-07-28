using healthTracker.Dtos;
using healthTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace healthTracker.Models
{
    public class User : IBaseClass
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        public ProviderEnum Provider { get; set; }
        [Required]
        public UnitsEnum Units { get; set; }

        public override IBaseOutDto ConvertToDto()
        {
            UserOutDto dto = new()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Gender = Gender,
                DateCreated = DateCreated,
                DateUpdated = DateUpdated,
                Provider = Provider,
                Units = Units
            };

            return dto;
        }
    }
}
