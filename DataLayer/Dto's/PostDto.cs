using EigenprojectProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EigenprojectProject.Data.Dto_s
{
    public class PostDto : IPost
    {
        public string Titel { get; set; }
        public string Vraag { get; set; }
        public string Afbeelding { get; set; }
        public int Id { get; set; }
        public int PostId { get; set; }
    }
}
