using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Repositories
{
    public interface ITributacaoRepository
    {
        void Adicionar(Tributacao tributacao);

        void Atualizar(Tributacao tributacao);

        void Remover(Guid id);

        Tributacao ObterPorId(Guid id);

        IEnumerable<Tributacao> ObterTodos();

        IEnumerable<Tributacao> Buscar(Expression<Func<Tributacao, bool>> predicate);
    }
}
