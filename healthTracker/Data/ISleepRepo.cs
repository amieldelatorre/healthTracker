using healthTracker.Models;

namespace healthTracker.Data
{
    public interface ISleepRepo
    {
        public Sleep? GetById(int id);
        public IEnumerable<Sleep> GetByUserId(int userId);
        public bool Add(Sleep sleep);
        public bool Update(Sleep sleep);
        public bool Delete(Sleep sleep);
    }
}
