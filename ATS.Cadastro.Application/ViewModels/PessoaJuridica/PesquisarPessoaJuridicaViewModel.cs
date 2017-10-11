using ATS.Cadastro.Application.Commands;
using System.Collections.Generic;

namespace ATS.Cadastro.Application.ViewModels.PessoaJuridica
{
    public class PesquisarPessoaJuridicaViewModel
    {
        public string CNPJ { get; set; }

        public string RazaoSocial { get; set; }

        public IEnumerable<PessoaJuridicaCommands> ListaDePessoasJuridicas { get; set; }
    }
}
