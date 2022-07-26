namespace healthTracker.Dtos
{
    public abstract class IBaseOutDto
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
