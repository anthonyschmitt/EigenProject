using System;
using System.Collections.Generic;
using System.Text;
using EigenprojectProject.Data.ContextInterfaces;
using EigenprojectProject.Interfaces;

namespace EigenprojectProject.Data
{
    public class PostRepository : IPostContext
    {
        private readonly IPostContext _context;

        public PostRepository(IPostContext context)
        {
            _context = context;
        }

        public void AddPost(IPost newPost, int Id)
        {
            _context.AddPost(newPost, Id);
        }

        public IList<IPost> GetAllPosts()
        {
            return _context.GetAllPosts();
        }

        public bool DeletePost(int id)
        {
            return _context.DeletePost(id);
        }
    } 
}
