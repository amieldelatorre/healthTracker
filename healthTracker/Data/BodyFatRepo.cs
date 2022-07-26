using healthTracker.Models;

namespace healthTracker.Data
{
    public class BodyFatRepo : IBodyFatRepo
    {
        public readonly HealthTrackerContext _dbContext;
        
        public BodyFatRepo(HealthTrackerContext context)
        {
            _dbContext = context;   
        }

        public BodyFat? GetById(int id)
        {
            return _dbContext.BodyFats.SingleOrDefault(bf => bf.Id == id);
        }

        public IEnumerable<BodyFat> GetByUserId(int userId)
        {
            return _dbContext.BodyFats.Where(bf => bf.UserId == userId);
        }

        public bool Add(BodyFat bodyFat)
        {
            _dbContext.BodyFats.Add(bodyFat);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public bool Delete(BodyFat bodyFat)
        {
            _dbContext.Remove(bodyFat);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public bool Update(BodyFat updatedBodyFat)
        {
            _dbContext.Update(updatedBodyFat);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }
    }
}
