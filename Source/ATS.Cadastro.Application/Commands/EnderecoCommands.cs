using ATS.Core.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace ATS.Cadastro.Application.Commands
{
    public class EnderecoCommands
    {
        public Guid? IdEndereco { get; set; }

        public Guid? PessoaId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [MaxLength(200, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMaximoDeCaracteresPermitidoVM")]
        public string Logradouro { get; set; }

        [MaxLength(200, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMaximoDeCaracteresPermitidoVM")]
        public string Complemento { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [MaxLength(10, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMaximoDeCaracteresPermitidoVM")]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "SomenteNumeros")]
        public string Numero { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [MaxLength(80, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMaximoDeCaracteresPermitidoVM")]
        public string Bairro { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        public Guid? CidadeId { get; set; }

        public CidadeCommands Cidade { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        public Guid? EstadoId { get; set; }

        public EstadoCommands Estado { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [MaxLength(9, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMaximoDeCaracteresPermitidoVM")]
        [RegularExpression("^\\d{5}-\\d{3}$", ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CEPInvalido")]
        public string Cep { get; set; }
    }
}
