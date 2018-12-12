using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet_Covoiturage.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(Ressources.langue))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberBrowser", ResourceType = typeof(Ressources.langue))]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(Ressources.langue))]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Ressources.langue))]
        public string Password { get; set; }

        [Display(Name = "RememberPassword", ResourceType = typeof(Ressources.langue))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Ressources.langue))]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string Prenom { get; set; }

        [Required]
        [Display(Name = "Telephone", ResourceType = typeof(Ressources.langue))]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Town", ResourceType = typeof(Ressources.langue))]
        public string ville { get; set; }

        [Required]
        [Display(Name = "Age", ResourceType = typeof(Ressources.langue))]
        public int Age { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Ressources.langue))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Ressources.langue))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Ressources.langue))]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterViewModelChauffeur : RegisterViewModel
    {

        [Required]
        [Display(Name = "LicenseDate", ResourceType = typeof(Ressources.langue))]
        public DateTime DatePermis { get; set; }

        [Display(Name = "HireDate", ResourceType = typeof(Ressources.langue))]
        public DateTime DateEmbauche { get; set; }

        [Required]
        [Display(Name = "Model", ResourceType = typeof(Ressources.langue))]
        public string Modele { get; set; }
        [Required]
        [Display(Name = "RoadDate", ResourceType = typeof(Ressources.langue))]
        public DateTime DateMiseEnRoute { get; set; }
        [Required]
        [Display(Name = "Places", ResourceType = typeof(Ressources.langue))]
        public int NombrePlace { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Ressources.langue))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Ressources.langue))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Ressources.langue))]
        [Compare("Password", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Ressources.langue))]
        public string Email { get; set; }
    }
}
