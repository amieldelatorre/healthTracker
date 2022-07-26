using healthTracker.Models;

namespace healthTracker.Data
{
    public class WeightRepo : IWeightRepo
    {
        private readonly HealthTrackerContext _dbContext;

        public WeightRepo(HealthTrackerContext context) : base(context)
        {
            _dbContext = context;
        }

        public override Weight? GetById(int id)
        {
            return _dbContext.Weights.SingleOrDefault(bf => bf.Id == id);
        }

        public override IEnumerable<Weight> GetByUserId(int userId)
        {
            return _dbContext.Weights.Where(bf => bf.UserId == userId);
        }

        public override bool Add(Weight weight)
        {
            _dbContext.Weights.Add(weight);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public override bool Delete(Weight weight)
        {
            _dbContext.Remove(weight);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public override bool Update(Weight updatedWeight)
        {
            _dbContext.Update(updatedWeight);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }
    }
}
