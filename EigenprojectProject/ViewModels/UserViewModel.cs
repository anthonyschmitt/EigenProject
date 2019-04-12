using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using EigenprojectProject.Controllers;

namespace EigenprojectProject.ViewModels
{
    public class UserViewModel:IUser
    {

        public int UserId { get; set; }

        [Display(Name = "Gebruikersnaam")]
        [Required(ErrorMessage = "Je moet een gebruikersnaam invullen.")]
        public string Username { get; set; }

        [Display(Name = "Voornaam")]
        [Required(ErrorMessage = "Je moet een voornaam invullen.")]
        public string Firstname { get; set; }
        [Display(Name = "Achternaam")]
        [Required(ErrorMessage = "Je moet een achternaam invullen.")]
        public string Lastname { get; set; }

        [Display(Name = "Email Adres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vul een geldige emailadres in.")]
        [Required(ErrorMessage = "Je moet een e-mailadres invullen.")]
        public string Email { get; set; }

        [Display(Name = "Bevestig Email")]
        [Required(ErrorMessage = "Je moet bevestig email invullen.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vul een geldige emailadres in.")]
        [Compare("Email", ErrorMessage = "De email en bevestig email moet overeen komen.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Wachtwoord")]
        [Required(ErrorMessage = "Je moet een wachtwoord invullen.")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Wachtwoord is te kort.")]
        public string Password { get; set; }

        [Display(Name = "Bevestig wachtwoord")]
        [Required(ErrorMessage = "Je moet bevestig wachtwoord invullen.")]
        [Compare("Password", ErrorMessage = "Het wachtwoord en bevestig wachtwoord moet overeen komen.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Bevoegdheid is een verplicht veld.")]
        [Display(Name = "Bevoegdheid")]
        public AccessLevel AccessLevel { get; set; }
    }
}
