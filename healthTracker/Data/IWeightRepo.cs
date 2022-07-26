using healthTracker.Models;

namespace healthTracker.Data
{
    public interface IWeightRepo
    {
        public Weight? GetById(int id);
        public IEnumerable<Weight> GetByUserId(int userId);
        public bool Add(Weight weight);
        public bool Update(Weight weight);
        public bool Delete(Weight weight);
    }
}
