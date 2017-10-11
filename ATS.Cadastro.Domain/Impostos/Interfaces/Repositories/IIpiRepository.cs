using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Repositories
{
    public interface IIpiRepository
    {
        void Adicionar(Ipi ipi);

        void Atualizar(Ipi ipi);

        void Remover(Guid id);

        Ipi ObterPorId(Guid id);

        IEnumerable<Ipi> ObterTodos();

        IEnumerable<Ipi> Buscar(Expression<Func<Ipi, bool>> predicate);
    }
}
