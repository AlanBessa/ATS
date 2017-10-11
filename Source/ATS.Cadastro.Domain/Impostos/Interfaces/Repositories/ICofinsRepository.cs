using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Repositories
{
    public interface ICofinsRepository
    {
        void Adicionar(Cofins cofins);

        void Atualizar(Cofins cofins);

        void Remover(Guid id);

        Cofins ObterPorId(Guid id);

        IEnumerable<Cofins> ObterTodos();

        IEnumerable<Cofins> Buscar(Expression<Func<Cofins, bool>> predicate);
    }
}
