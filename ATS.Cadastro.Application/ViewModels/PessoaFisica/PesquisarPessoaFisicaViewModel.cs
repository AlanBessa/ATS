using ATS.Cadastro.Application.Commands;
using System.Collections.Generic;

namespace ATS.Cadastro.Application.ViewModels.PessoaFisica
{
    public class PesquisarPessoaFisicaViewModel
    {
        public string CPF { get; set; }

        public string Nome { get; set; }

        public IEnumerable<PessoaFisicaCommands> ListaDePessoasFisicas { get; set; }
    }
}
