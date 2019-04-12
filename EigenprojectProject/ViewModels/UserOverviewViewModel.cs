using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;

namespace EigenprojectProject.ViewModels
{
    public class UserOverviewViewModel :IUser
    {
        public UserOverviewViewModel(int id, string username, string firstname, string lastname, string email, string password, AccessLevel level)
        {
            UserId = id;
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            AccessLevel = level;
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
