using healthTracker.Models;

namespace healthTracker.Data
{
    public abstract class IUserRepo : IRepo
    {
        public abstract User? GetById(int id);
        public abstract bool EmailExists(string email);
        public abstract User? GetUserByEmail(string email);
        public abstract bool Add(User user);
        public abstract bool Delete(User user);
        public abstract bool Update(User user);
        public abstract bool IsValidLogin(string email, string password);
    }
}
