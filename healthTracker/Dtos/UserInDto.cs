using healthTracker.Models.Enums;

namespace healthTracker.Dtos
{
    public class UserInDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public GenderEnum Gender { get; set; }
        public ProviderEnum Provider { get; set; }
        public UnitsEnum Units { get; set; }
    }
}
