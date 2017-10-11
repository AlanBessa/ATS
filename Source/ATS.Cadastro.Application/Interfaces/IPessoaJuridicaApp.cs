using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Application.ViewModels.PessoaJuridica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Application.Interfaces
{
    public interface IPessoaJuridicaApp
    {
        PessoaJuridicaCommands CadastrarPessoaJuridica(CadastrarPessoaJuridicaViewModel cadastrarPessoaJuridicaVM);

        PessoaJuridicaCommands AtualizarPessoaJuridica(EditarPessoaJuridicaViewModel editarPessoaJuridicaVM);

        void ExcluirPessoaJuridica(Guid id);

        PesquisarPessoaJuridicaViewModel PesquisarPessoaJuridica(PesquisarPessoaJuridicaViewModel pesquisarPessoaJuridicaVM);

        EditarPessoaJuridicaViewModel ObterDadosPessoaJuridica(Guid idPessoa);
    }
}
