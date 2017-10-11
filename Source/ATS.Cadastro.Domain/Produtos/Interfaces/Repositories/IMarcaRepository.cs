using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Produtos.Interfaces.Repositories
{
    public interface IMarcaRepository
    {
        void Adicionar(Marca marca);

        void Atualizar(Marca marca);

        void Remover(Guid id);

        Marca ObterPorId(Guid id);

        IEnumerable<Marca> ObterTodos();

        IEnumerable<Marca> Buscar(Expression<Func<Marca, bool>> predicate);
    }
}
