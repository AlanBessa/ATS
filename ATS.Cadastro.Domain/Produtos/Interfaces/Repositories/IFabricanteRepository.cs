using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Produtos.Interfaces.Repositories
{
    public interface IFabricanteRepository
    {
        void Adicionar(Fabricante fabricante);

        void Atualizar(Fabricante fabricante);

        void Remover(Guid id);

        Fabricante ObterPorId(Guid id);

        IEnumerable<Fabricante> ObterTodos();

        IEnumerable<Fabricante> Buscar(Expression<Func<Fabricante, bool>> predicate);
    }
}
