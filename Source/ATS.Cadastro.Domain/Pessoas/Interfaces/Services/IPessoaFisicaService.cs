using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Pessoas.Interfaces.Services
{
    public interface IPessoaFisicaService
    {
        PessoaFisica Adicionar(PessoaFisica pessoaFisica);

        PessoaFisica Atualizar(PessoaFisica pessoaFisica);

        void Remover(Guid id);

        PessoaFisica ObterPorId(Guid id);

        IEnumerable<PessoaFisica> ObterTodos();

        IEnumerable<PessoaFisica> ObterTodosPorFiltro(string cpf, string nome);

        IEnumerable<EEstadoCivil> ObterTodosOsEstadosCivis();
    }
}
