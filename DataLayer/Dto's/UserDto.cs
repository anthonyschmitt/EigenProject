using Interfaces;

namespace DataLayer
{
    internal class UserDto:IUser
    {
        public UserDto()
        {
        }

        public UserDto(int userId, string username, string firstname, string lastname, string email, string password, AccessLevel number )
        {
            UserId = userId;
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            AccessLevel = number;
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccessLevel AccessLevel { get ; set; }
    }
}
