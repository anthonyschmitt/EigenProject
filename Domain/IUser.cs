﻿namespace Interfaces
{
    public interface IUser
    {
        int UserId { get; set; }
        string Username { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        AccessLevel AccessLevel { get; set; }
    }
}
