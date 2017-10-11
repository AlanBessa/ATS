using System.ComponentModel.DataAnnotations;

namespace ATS.Cadastro.Infra.CrossCutting.Identity.Modelo
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
