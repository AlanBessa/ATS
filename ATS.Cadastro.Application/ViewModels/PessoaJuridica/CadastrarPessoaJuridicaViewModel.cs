using ATS.Cadastro.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Cadastro.Application.ViewModels.PessoaJuridica
{
    public class CadastrarPessoaJuridicaViewModel
    {
        public PessoaJuridicaCommands DadosDaPessoaJuridica { get; set; }

        public EnderecoCommands DadosDeEndereco { get; set; }

        public MeioDeComunicacaoCommands Email { get; set; }

        public MeioDeComunicacaoCommands Telefone { get; set; }

        public MeioDeComunicacaoCommands Celular { get; set; }

        public MeioDeComunicacaoCommands Site { get; set; }

        public MeioDeComunicacaoCommands RedeSocial { get; set; }
        
        public IEnumerable<SelectListItem> CidadeList { get; set; }

        public IEnumerable<SelectListItem> EstadoCivilList { get; set; }

        public IEnumerable<SelectListItem> EstadoList { get; set; }

        public IEnumerable<SelectListItem> TipoDeMeioDeComunicacaoList { get; set; }
    }
}
