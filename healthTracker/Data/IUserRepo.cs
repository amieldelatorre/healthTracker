﻿using healthTracker.Models;

namespace healthTracker.Data
{
    public interface IUserRepo
    {
        public User? GetById(int id);
        public bool EmailExists(string email);
        public bool Add(User user);
        public bool Delete(User user);
        public bool Update(User user);
    }
}