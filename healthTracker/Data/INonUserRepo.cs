using healthTracker.Models;

namespace healthTracker.Data
{
    public abstract class INonUserRepo
    {
        private readonly HealthTrackerContext _context;

        public INonUserRepo(HealthTrackerContext context)
        {
            _context = context;
        }
        public User? GetUserById(int id)
        {
            UserRepo userRepo = new(_context);
            return userRepo.GetById(id);
        }
    }
}
