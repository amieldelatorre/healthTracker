using healthTracker.Models;

namespace healthTracker.Data
{
    public abstract class IWeightRepo : INonUserRepo
    {
        public IWeightRepo(HealthTrackerContext context) : base(context)
        {
        }

        public abstract Weight? GetById(int id);
        public abstract IQueryable<Weight> GetByUserId(int userId);
        public abstract bool Add(Weight weight);
        public abstract bool Update(Weight weight);
        public abstract bool Delete(Weight weight);
    }
}
