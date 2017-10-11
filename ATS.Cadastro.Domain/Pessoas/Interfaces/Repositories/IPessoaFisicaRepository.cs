using ATS.Cadastro.Domain.Pessoas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories
{
    public interface IPessoaFisicaRepository
    {
        void Adicionar(PessoaFisica pessoaFisica);

        void Atualizar(PessoaFisica pessoaFisica);

        void Remover(Guid id);

        PessoaFisica ObterPorId(Guid id);

        IEnumerable<PessoaFisica> ObterTodos();

        IEnumerable<PessoaFisica> Buscar(Expression<Func<PessoaFisica, bool>> predicate);

        PessoaFisica ObterPorCPF(string cpf);

        PessoaFisica ObterPorRG(string rg);

        IEnumerable<PessoaFisica> ObterTodosPorFiltro(string cpf, string nome);
    }
}
