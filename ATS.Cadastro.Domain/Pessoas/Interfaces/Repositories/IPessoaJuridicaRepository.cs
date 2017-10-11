using ATS.Cadastro.Domain.Pessoas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories
{
    public interface IPessoaJuridicaRepository
    {
        void Adicionar(PessoaJuridica pessoaJuridica);

        void Atualizar(PessoaJuridica pessoaJuridica);

        void Remover(Guid id);

        PessoaJuridica ObterPorId(Guid id);

        IEnumerable<PessoaJuridica> ObterTodos();

        IEnumerable<PessoaJuridica> Buscar(Expression<Func<PessoaJuridica, bool>> predicate);

        PessoaJuridica ObterPorCNPJ(string cnpj);

        IEnumerable<PessoaJuridica> ObterTodosPorFiltro(string cnpj, string razaoSocial);
    }
}
