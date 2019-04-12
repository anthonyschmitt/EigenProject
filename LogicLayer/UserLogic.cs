using System;
using System.Collections.Generic;
using System.Net;
using DataLayer;
using DataLayer.ContextInterfaces;
using Interfaces;
using LogicLayer.Helpers;

namespace LogicLayer
{
    public class UserLogic
    {
        private UserRepository Repository { get; }

        public UserLogic(IUserContext context)
        {
            Repository = new UserRepository(context);
        }

        public bool Login(string username, string password)
        {
            var encrypt = new Encrypt();
            password = encrypt.Hash(password);
            return Repository.CheckCredential(username, password);
        }

        public bool IsUsernameTaken(string username)
        {
            return Repository.IsUsernameTaken(username);
        }

        public void AddUser(IUser newUser)
        {
            var encrypt = new Encrypt();
            newUser.Password = encrypt.Hash(newUser.Password);
            Repository.AddUser(newUser);
        }

        public void UpdateUser(IUser updatedUser,int id)
        {
            var encrypt = new Encrypt();
            updatedUser.Password = encrypt.Hash(updatedUser.Password);
            Repository.UpdateUser(updatedUser, id);
        }

        public IUser GetUserByUsername(string username)
        {
            return Repository.GetUserByUsername(username);
        }

        public IEnumerable<IUser> GetUsers()
        {
            return Repository.GetAllUsers();
        }
    }
}
