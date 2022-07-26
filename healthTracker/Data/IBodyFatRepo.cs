using healthTracker.Models;

namespace healthTracker.Data
{
    public interface IBodyFatRepo
    {
        public BodyFat? GetById(int id);
        public IEnumerable<BodyFat> GetByUserId(int userId);
        public bool Add(BodyFat bodyFat);
        public bool Update(BodyFat bodyFat);
        public bool Delete(BodyFat bodyFat);

    }
}
