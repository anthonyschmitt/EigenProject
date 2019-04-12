using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.ContextInterfaces;
using Interfaces;

namespace DataLayer
{
    public class UserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public void AddUser(IUser newUser)
        {
            _context.AddUser(newUser);
        }

        public void UpdateUser(IUser updatedUser, int id)
        {
            _context.UpdateUser(updatedUser, id);
        }

        public IUser GetUserById(int userId)
        {
            return _context.GetUserById(userId);
        }
        public IUser GetUserByUsername(string username)
        {
            return _context.GetUserByUsername(username);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _context.GetAllUsers();
        }

        public bool CheckCredential(string username, string hashedPassword)
        {
            return _context.CheckCredential(username, hashedPassword);
        }

        public bool IsUsernameTaken(string username)
        {
            return _context.IsUsernameTaken(username);
        }
    }
}
