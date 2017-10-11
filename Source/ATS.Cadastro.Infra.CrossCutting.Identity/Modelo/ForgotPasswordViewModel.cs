using System.ComponentModel.DataAnnotations;

namespace ATS.Cadastro.Infra.CrossCutting.Identity.Modelo
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
