using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Produtos.Interfaces.Repositories
{
    public interface ICorRepository
    {
        void Adicionar(Cor cor);

        void Atualizar(Cor cor);

        void Remover(Guid id);

        Cor ObterPorId(Guid id);

        IEnumerable<Cor> ObterTodos();

        IEnumerable<Cor> Buscar(Expression<Func<Cor, bool>> predicate);
    }
}
