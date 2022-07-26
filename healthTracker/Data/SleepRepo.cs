using healthTracker.Models;

namespace healthTracker.Data
{
    public class SleepRepo : ISleepRepo
    {
        public readonly HealthTrackerContext _dbContext;

        public SleepRepo(HealthTrackerContext context)
        {
            _dbContext = context;
        }

        public Sleep? GetById(int id)
        {
            return _dbContext.Sleeps.SingleOrDefault(bf => bf.Id == id);
        }

        public IEnumerable<Sleep> GetByUserId(int userId)
        {
            return _dbContext.Sleeps.Where(bf => bf.UserId == userId);
        }

        public bool Add(Sleep sleep)
        {
            _dbContext.Sleeps.Add(sleep);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public bool Delete(Sleep sleep)
        {
            _dbContext.Remove(sleep);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public bool Update(Sleep updatedSleep)
        {
            _dbContext.Update(updatedSleep);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }
    }
}
