using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Funcionarios.Interfaces.Services
{
    public interface IHistoricoDeCargoService
    {
        void Adicionar(HistoricoDeCargo historicoDeCargo);

        void Atualizar(HistoricoDeCargo historicoDeCargo);

        void Remover(Guid id);

        HistoricoDeCargo ObterPorId(Guid id);

        IEnumerable<HistoricoDeCargo> ObterTodos();
    }
}
