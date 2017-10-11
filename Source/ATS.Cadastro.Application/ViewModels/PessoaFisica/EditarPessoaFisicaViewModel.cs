using ATS.Cadastro.Application.Commands;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ATS.Cadastro.Application.ViewModels.PessoaFisica
{
    public class EditarPessoaFisicaViewModel
    {
        public PessoaFisicaCommands DadosDaPessoaFisica { get; set; }
        
        public EnderecoCommands DadosDeEndereco { get; set; }

        public MeioDeComunicacaoCommands MeioDeComunicacao { get; set; }

        public IEnumerable<EnderecoCommands> ListaDeEnderecos { get; set; }

        public IEnumerable<MeioDeComunicacaoCommands> ListaDeMeioDeComunicacao { get; set; }
        
        public IEnumerable<SelectListItem> EstadoCivilList { get; set; }

        public IEnumerable<SelectListItem> CidadeList { get; set; }

        public IEnumerable<SelectListItem> EstadoList { get; set; }

        public IEnumerable<SelectListItem> TipoDeMeioDeComunicacaoList { get; set; }
    }
}
