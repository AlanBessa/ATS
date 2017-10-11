using ATS.Cadastro.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Cadastro.Application.ViewModels.PessoaJuridica
{
    public class EditarPessoaJuridicaViewModel
    {
        public PessoaJuridicaCommands DadosDaPessoaJuridica { get; set; }

        public EnderecoCommands DadosDeEndereco { get; set; }

        public MeioDeComunicacaoCommands MeioDeComunicacao { get; set; }

        public IEnumerable<EnderecoCommands> ListaDeEnderecos { get; set; }

        public IEnumerable<MeioDeComunicacaoCommands> ListaDeMeioDeComunicacao { get; set; }

        public IEnumerable<ContatoCommands> ListaDeContatos { get; set; }

        public IEnumerable<SelectListItem> CidadeList { get; set; }

        public IEnumerable<SelectListItem> EstadoCivilList { get; set; }

        public IEnumerable<SelectListItem> EstadoList { get; set; }

        public IEnumerable<SelectListItem> TipoDeMeioDeComunicacaoList { get; set; }
    }
}
