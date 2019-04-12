using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace LogicLayer.Models
{
    internal class User:IUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
