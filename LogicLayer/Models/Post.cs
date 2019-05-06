using System;
using System.Collections.Generic;
using System.Text;
using EigenprojectProject.Interfaces;

namespace EigenprojectProject.Logic.Models
{
    public class Post : IPost
    {
        public string Titel { get; set; }
        public string Vraag { get; set; }
        public string Afbeelding { get; set; }
        public int Id { get; set; }
        public int PostId { get; set; }
    }
}
