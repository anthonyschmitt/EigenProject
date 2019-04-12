using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using DataLayer.ContextInterfaces;
using DataLayer.Helpers;
using Interfaces;

namespace DataLayer
{
    public class UserContext : IUserContext
    {

        private readonly DatabaseConnection _connection;

        public UserContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public void AddUser(IUser newUser)
        {
            _connection.SqlConnection.Open();
            var command = new SqlCommand("INSERT INTO [userep] (userUsername,userPassword,userEmail,userFname,userLname, userAccLevel) VALUES(@Username,@Password,@Email,@FirstName,@LastName, @Acclevel)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Username", newUser.Username);
            command.Parameters.AddWithValue("@Password", newUser.Password);
            command.Parameters.AddWithValue("@Email", newUser.Email);
            command.Parameters.AddWithValue("@FirstName", newUser.Firstname);
            command.Parameters.AddWithValue("@LastName", newUser.Lastname);
            command.Parameters.AddWithValue("@Acclevel", (int)newUser.AccessLevel);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public void UpdateUser(IUser updatedUserData, int id)
        {
            _connection.SqlConnection.Open();
            var command = new SqlCommand("UPDATE [userep] SET userUsername=@Username,userPassword =@Password,userEmail = @Email,userFname=@Firstname,userLname=@Lastname  WHERE userId = @UserId", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Username", updatedUserData.Username);
            command.Parameters.AddWithValue("@Password", updatedUserData.Password);
            command.Parameters.AddWithValue("@Email", updatedUserData.Email);
            command.Parameters.AddWithValue("@FirstName", updatedUserData.Firstname);
            command.Parameters.AddWithValue("@LastName", updatedUserData.Lastname);
            command.Parameters.AddWithValue("@UserId", id);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public IUser GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public IUser GetUserByUsername(string username)
        {
            _connection.SqlConnection.Open();
            var model = new UserDto();
            var command = new SqlCommand("SELECT * FROM [userep] WHERE userUsername = @UserName", _connection.SqlConnection);
            command.Parameters.AddWithValue("@UserName", username);
            command.ExecuteNonQuery();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    model.Username = reader.GetString(5);
                    model.Password = reader.GetString(6);
                    model.Firstname = reader.GetString(2);
                    model.Lastname = reader.GetString(1);
                    model.Email = reader.GetString(7);
                    model.UserId = reader.GetInt32(0);
                    model.AccessLevel = (AccessLevel)reader.GetInt32(8);
                }
            }
            _connection.SqlConnection.Close();
            return model;
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            _connection.SqlConnection.Open();
            var users = new List<IUser>();
            var command = new SqlCommand("SELECT * FROM [userep]", _connection.SqlConnection);
            command.ExecuteNonQuery();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new UserDto(reader.GetInt32(0), reader.GetString(5), reader.GetString(1),
                        reader.GetString(2), reader.GetString(7),reader.GetString(6), (AccessLevel)reader.GetInt32(8)));
                }
            }

            _connection.SqlConnection.Close();
            return users;
        }

        public bool CheckCredential(string username, string hashedPassword)
        {
            var correct = false;
            _connection.SqlConnection.Open();
            var command = new SqlCommand("SELECT userId,userUsername,userPassword FROM [userep] WHERE userUsername = (@Username) AND userPassword = (@Password)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", hashedPassword);
            command.ExecuteNonQuery();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    correct = true;
                }
            }
            _connection.SqlConnection.Close();
            return correct;
        }

        public bool IsUsernameTaken(string username)
        {
            var taken = false;
            _connection.SqlConnection.Open();
            var command = new SqlCommand("SELECT userUsername FROM [userep] WHERE userUsername = @UserName", _connection.SqlConnection);
            command.Parameters.AddWithValue("@UserName", username);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    taken = true;
                }
            }
            _connection.SqlConnection.Close();
            return taken;
        }

        private int Acclevel;

        public int GetAccLevel(string username)
        {
            _connection.SqlConnection.Open();
            var command = new SqlCommand("SELECT * FROM [userep] WHERE userUsername = @UserName ", _connection.SqlConnection);
            command.Parameters.AddWithValue("@UserName", username);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Acclevel = reader.GetInt32(8);
                }
            }
            _connection.SqlConnection.Close();
            return Acclevel;
        }
    }
}
