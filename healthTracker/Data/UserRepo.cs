using healthTracker.Models;

namespace healthTracker.Data
{
    public class UserRepo : IUserRepo
    {
        public readonly HealthTrackerContext _dbContext;
        public UserRepo(HealthTrackerContext context)
        {
            _dbContext = context;   
        }

        public override User? GetById(int id)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Id == id);   
        }

        public override bool EmailExists(string email)
        {
            User? user = _dbContext.Users.FirstOrDefault(u => u.Email == email); 

            if (user == null)
                return false;
            return true;
        }

        public override User? GetUserByEmail(string email)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Email == email);
        }

        public override bool Add(User user)
        {
            _dbContext.Users.Add(user);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }
        
        public override bool Delete(User user)
        {
            // todo delete everything with association to this user! 
            _dbContext.Remove(user);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public override bool Update(User updatedUser)
        {
            _dbContext.Update(updatedUser);
            int saveResults = _dbContext.SaveChanges();
            return saveResults > 0;
        }

        public override bool IsValidLogin(string email, string password)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email ==email && u.Password == password) != null;
        }
    }

}
