using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATS.Cadastro.Application.Commands
{
    public class PessoaFisicaCommands
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
        public string Nome { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [RegularExpression("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$", ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CPFInvalido")]
        public string CPF { get; set; }

        public string RG { get; set; }

        public string TituloDeEleitor { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataDeNascimento { get; set; }

        public string NomeDoPai { get; set; }

        public string NomeDaMae { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        public Guid? NaturalidadeId { get; set; }

        public EstadoCommands Naturalidade { get; set; }

        public string Nacionalidade { get; set; }

        public int Sexo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage), ErrorMessageResourceName = "CampoObrigatorio")]
        public EEstadoCivil EstadoCivil { get; set; }

        public string Salario { get; set; }
    }
}
