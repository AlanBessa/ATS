using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Funcionarios.Interfaces.Repositories
{
    public interface IHistoricoDeCargoRepository
    {
        void Adicionar(HistoricoDeCargo historicoDeCargo);

        void Atualizar(HistoricoDeCargo historicoDeCargo);

        void Remover(Guid id);

        HistoricoDeCargo ObterPorId(Guid id);

        IEnumerable<HistoricoDeCargo> ObterTodos();

        IEnumerable<HistoricoDeCargo> Buscar(Expression<Func<HistoricoDeCargo, bool>> predicate);
    }
}
