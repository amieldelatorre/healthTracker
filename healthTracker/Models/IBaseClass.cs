using healthTracker.Dtos;

namespace healthTracker.Models
{
    public abstract class IBaseClass
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public abstract IBaseOutDto ConvertToDto();
    }
}
