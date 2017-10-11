using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Repositories
{
    public interface IPisRepository
    {
        void Adicionar(Pis pis);

        void Atualizar(Pis pis);

        void Remover(Guid id);

        Pis ObterPorId(Guid id);

        IEnumerable<Pis> ObterTodos();

        IEnumerable<Pis> Buscar(Expression<Func<Pis, bool>> predicate);
    }
}
