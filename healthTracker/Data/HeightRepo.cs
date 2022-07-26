using healthTracker.Models;

namespace healthTracker.Data
{
    public class HeightRepo : IHeightRepo   
    {
        public readonly HealthTrackerContext _dbContext;

        public HeightRepo(HealthTrackerContext context)
        {
            _dbContext = context;
        }

        public Height? GetById(int id)
        {
            return _dbContext.Heights.SingleOrDefault(bf => bf.Id == id);
        }

        public IEnumerable<Height> GetByUserId(int userId)
        {
            return _dbContext.Heights.Where(bf => bf.UserId == userId);
        }

        public bool Add(Height height)
        {
            _dbContext.Heights.Add(height);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public bool Delete(Height height)
        {
            _dbContext.Remove(height);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public bool Update(Height updatedHeight)
        {
            _dbContext.Update(updatedHeight);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }
    }
}
