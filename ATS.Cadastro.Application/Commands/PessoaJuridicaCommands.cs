using ATS.Core.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace ATS.Cadastro.Application.Commands
{
    public class PessoaJuridicaCommands
    {
        public Guid? IdPessoa { get; set; }

        public string LimiteDeCredito { get; set; }

        public string Referencias { get; set; }

        public string Conceito { get; set; }

        public string SPC { get; set; }

        public string Status { get; set; }

        public string Observacao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataDaUltimaCompra { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [MinLength(6, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMinimoDeCaracteresPermitidoVM")]
        [MaxLength(200, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMaximoDeCaracteresPermitidoVM")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [MinLength(6, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMinimoDeCaracteresPermitidoVM")]
        [MaxLength(200, ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoComMaximoDeCaracteresPermitidoVM")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [RegularExpression("^(\\d{2}.\\d{3}.\\d{3}/\\d{4}-\\d{2})|(\\d{14})$", ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CNPJInvalido")]
        public string CNPJ { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        public string Inscricao { get; set; }
        
        public Guid? SocioId { get; set; }

        public PessoaFisicaCommands Socio { get; set; }

        public Guid? SocioMenorId { get; set; }

        public PessoaFisicaNoValidationCommands SocioMenor { get; set; }
    }
}
