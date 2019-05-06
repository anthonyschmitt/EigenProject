using System;
using System.Collections.Generic;
using System.Text;

namespace EigenprojectProject.Interfaces
{
    public interface IPost
    {
        string Titel { get; set; }
        string Vraag { get; set; }
        string Afbeelding { get; set; }
        int Id { get; set; }
        int PostId { get; set; }
    }
}
