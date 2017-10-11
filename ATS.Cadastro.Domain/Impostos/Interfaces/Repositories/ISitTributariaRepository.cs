using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Repositories
{
    public interface ISitTributariaRepository
    {
        void Adicionar(SitTributaria sitTributaria);

        void Atualizar(SitTributaria sitTributaria);

        void Remover(Guid id);

        SitTributaria ObterPorId(Guid id);

        IEnumerable<SitTributaria> ObterTodos();

        IEnumerable<SitTributaria> Buscar(Expression<Func<SitTributaria, bool>> predicate);
    }
}
