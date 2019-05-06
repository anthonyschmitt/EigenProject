using System.Data.SqlClient;
using EigenprojectProject.Data.ContextInterfaces;
using EigenprojectProject.Interfaces;
using DataLayer.Helpers;
using System.Collections.Generic;
using EigenprojectProject.Data.Dto_s;

namespace EigenprojectProject.Data
{
    public class PostContext : IPostContext
    {
        private readonly DatabaseConnection _connection;
        public PostContext(DatabaseConnection connection)
        {
            _connection = connection;
        }
        public void AddPost(IPost newPost,int Id)
        {

            _connection.SqlConnection.Open();
            var command = new SqlCommand("INSERT INTO [post] (userId,postTitle,postReply, postImage) VALUES(@Id,@Titel,@Vraag,@Afbeelding)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Titel", newPost.Titel);
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Vraag", newPost.Vraag);
            command.Parameters.AddWithValue("@Afbeelding", newPost.Afbeelding);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }
        public IList<IPost> GetAllPosts()
        {
            IList<IPost> toReturn = new List<IPost>();
            _connection.SqlConnection.Open();
            var command = new SqlCommand("SELECT userId, postTitle, postReply, postImage,postId FROM [post]", _connection.SqlConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    IPost IpostReturn = new PostDto
                    {
                        Id = reader.GetInt32(0),
                        Titel = reader.GetString(1),
                        Vraag = reader.GetString(2),
                        Afbeelding = reader.GetString(3),
                        PostId = reader.GetInt32(4)
                    };
                    toReturn.Add(IpostReturn);
                }
            }
            _connection.SqlConnection.Close();
            return toReturn;
        }
        public bool DeletePost(int id)
        {
           _connection.SqlConnection.Open();
            var command = new SqlCommand("DELETE FROM [post] WHERE postId= @postId", _connection.SqlConnection);
            command.Parameters.AddWithValue("@postId", id);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
            return true;
        }
    }
}