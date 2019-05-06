using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using System.ComponentModel.DataAnnotations;
using EigenprojectProject.Interfaces;

namespace EigenprojectProject.ViewModels.post
{
    public class PostViewModel
    {
        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Titel is verplicht")]
        public string Titel { get; set; }

        [Display(Name = "Vraag")]
        [Required(ErrorMessage = "Vraag is verplicht")]
        public string Vraag { get; set; }
        [Display(Name = "Afbeelding")]
        public string Afbeelding { get; set; }
        public int Id { get; set; }
        public int PostId { get; set; }

    }
}
