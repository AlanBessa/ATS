using System.ComponentModel.DataAnnotations;

namespace ATS.Cadastro.Infra.CrossCutting.Identity.Modelo
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nome da Role")]
        public string Name { get; set; }
    }
}
