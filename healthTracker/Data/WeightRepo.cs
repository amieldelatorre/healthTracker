using healthTracker.Models;

namespace healthTracker.Data
{
    public class WeightRepo : IWeightRepo
    {
        public readonly HealthTrackerContext _dbContext;

        public WeightRepo(HealthTrackerContext context)
        {
            _dbContext = context;
        }

        public Weight? GetById(int id)
        {
            return _dbContext.Weights.SingleOrDefault(bf => bf.Id == id);
        }

        public IEnumerable<Weight> GetByUserId(int userId)
        {
            return _dbContext.Weights.Where(bf => bf.UserId == userId);
        }

        public bool Add(Weight weight)
        {
            _dbContext.Weights.Add(weight);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public bool Delete(Weight weight)
        {
            _dbContext.Remove(weight);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public bool Update(Weight updatedWeight)
        {
            _dbContext.Update(updatedWeight);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }
    }
}
