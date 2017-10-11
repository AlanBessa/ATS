using ATS.Cadastro.Domain.Agendas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Agendas.Interfaces.Repositories
{
    public interface IAgendaRepository
    {
        void Adicionar(Agenda agenda);

        void Atualizar(Agenda agenda);

        void Remover(Guid id);

        Agenda ObterPorId(Guid id);

        IEnumerable<Agenda> ObterTodos();

        IEnumerable<Agenda> Buscar(Expression<Func<Agenda, bool>> predicate);
    }
}
