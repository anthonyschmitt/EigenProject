using System;
using System.Collections.Generic;
using System.Text;
using EigenprojectProject.Data.ContextInterfaces;
using EigenprojectProject.Interfaces;
using EigenprojectProject.Data;

namespace EigenprojectProject.Logic
{
    public class PostLogic
    {
        private PostRepository PostRepository { get; }
        public PostLogic(IPostContext context)
        {
            PostRepository = new PostRepository(context);
        }

        public void AddPost(IPost newPost, int Id)
        {
            PostRepository.AddPost(newPost, Id);
        }
        public IList<IPost> GetAllPosts()
        {
           return PostRepository.GetAllPosts();
        }

        public bool DeletePost(int id)
        {
            return PostRepository.DeletePost(id);
        }
    }
}
