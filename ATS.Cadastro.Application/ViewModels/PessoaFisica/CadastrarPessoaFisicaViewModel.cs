using ATS.Cadastro.Application.Commands;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ATS.Cadastro.Application.ViewModels.PessoaFisica
{
    public class CadastrarPessoaFisicaViewModel
    {
        public PessoaFisicaCommands DadosDaPessoaFisica { get; set; }

        public EnderecoCommands DadosDeEndereco { get; set; }

        public MeioDeComunicacaoCommands Email { get; set; }

        public MeioDeComunicacaoCommands Telefone { get; set; }

        public MeioDeComunicacaoCommands Celular { get; set; }

        public MeioDeComunicacaoCommands Site { get; set; }

        public MeioDeComunicacaoCommands RedeSocial { get; set; }

        public IEnumerable<SelectListItem> EstadoCivilList { get; set; }

        public IEnumerable<SelectListItem> CidadeList { get; set; }

        public IEnumerable<SelectListItem> EstadoList { get; set; }
    }
}
