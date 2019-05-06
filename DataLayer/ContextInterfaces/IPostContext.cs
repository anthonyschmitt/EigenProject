using System;
using System.Collections.Generic;
using System.Text;
using EigenprojectProject.Interfaces;

namespace EigenprojectProject.Data.ContextInterfaces
{
    public interface IPostContext
    {
        void AddPost(IPost newUser, int Id);
        IList<IPost> GetAllPosts();
        bool DeletePost(int id);
    }
}
