using ATS.Core.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace ATS.Cadastro.Application.Commands
{
    public class ContatoCommands
    {
        public Guid? IdContato { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [MinLength(6, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMinimoDeCaracteresPermitidoVM")]
        [MaxLength(200, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMaximoDeCaracteresPermitidoVM")]
        public string Nome { get; set; }

        [MaxLength(500, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMaximoDeCaracteresPermitidoVM")]
        public string Observacao { get; set; }

        [EmailAddress]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", 
            ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "EmailInvalido")]
        public string Email { get; set; }

        [Phone]
        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        public string Telefone { get; set; }
    }
}
