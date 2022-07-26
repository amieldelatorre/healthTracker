using healthTracker.Models;

namespace healthTracker.Data
{
    public interface IHeightRepo
    {
        public Height? GetById(int id);
        public IEnumerable<Height> GetByUserId(int userId);
        public bool Add(Height height);
        public bool Update(Height height);
        public bool Delete(Height height);
    }
}
