using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DataLayer.ContextInterfaces
{
    public interface IUserContext
    {
        void AddUser(IUser newUser);
        void UpdateUser(IUser updatedUserData, int id);
        IUser GetUserById(int userId);
        IUser GetUserByUsername(string username);
        IEnumerable<IUser> GetAllUsers();
        bool CheckCredential(string username, string hashedPassword);
        bool IsUsernameTaken(string username);
        int GetAccLevel(string username);

    }
}
