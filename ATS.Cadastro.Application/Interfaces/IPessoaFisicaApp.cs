using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Application.ViewModels.PessoaFisica;
using ATS.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Application.Interfaces
{
    public interface IPessoaFisicaApp
    {
        void ExcluirPessoaFisica(Guid id);

        PesquisarPessoaFisicaViewModel PesquisarPessoaFisica(PesquisarPessoaFisicaViewModel pesquisarPessoaFisicaVM);

        PessoaFisicaCommands CadastrarPessoaFisica(CadastrarPessoaFisicaViewModel cadastrarPessoaFisicaVM);

        PessoaFisicaCommands AtualizarPessoaFisica(EditarPessoaFisicaViewModel editarPessoaFisicaVM);

        EditarPessoaFisicaViewModel ObterDadosPessoaFisica(Guid idPessoa);

        IEnumerable<EEstadoCivil> ObterTodosOsEstadosCivis();
    }
}
