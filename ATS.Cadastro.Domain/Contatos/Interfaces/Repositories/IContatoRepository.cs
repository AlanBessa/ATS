using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Contatos.Interfaces.Repositories
{
    public interface IContatoRepository
    {
        void Adicionar(Contato contato);

        void Atualizar(Contato contato);

        void Remover(Guid id);

        Contato ObterPorId(Guid id);

        IEnumerable<Contato> ObterTodos();

        IEnumerable<Contato> Buscar(Expression<Func<Contato, bool>> predicate);
    }
}
