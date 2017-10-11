using System.ComponentModel.DataAnnotations;

namespace ATS.Cadastro.Infra.CrossCutting.Identity.Modelo
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}
