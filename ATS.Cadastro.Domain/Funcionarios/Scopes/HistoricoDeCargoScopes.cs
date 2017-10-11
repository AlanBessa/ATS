using ATS.Cadastro.Domain.Funcionarios.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;

namespace ATS.Cadastro.Domain.Funcionarios.Scopes
{
    public static class HistoricoDeCargoScopes
    {
        public static bool AdicionarCargoScopeEhValido(this HistoricoDeCargo historicoDeCargo, Cargo cargo)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(cargo, ErrorMessage.CargoObrigatorio)
            );
        }

        public static bool DefinirDataDeAdmissaoScopeEhValido(this HistoricoDeCargo historicoDeCargo, DateTime? data)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertDateNotNull(data, ErrorMessage.DataDeAdmissaoObrigatorio)
            );
        }

        public static bool DefinirFuncionarioScopeEhValido(this HistoricoDeCargo historicoDeCargo, Guid? funcionarioId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(funcionarioId, ErrorMessage.FuncionarioObrigatorio)
            );
        }

        public static bool DefinirHorariosDeTrabalhoScopeEhValido(this HistoricoDeCargo historicoDeCargo, string horarioDeEntrada, string horarioDeSaida)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(horarioDeEntrada, ErrorMessage.HorarioDeEntradaObrigatorio),
                AssertionConcern.AssertNotNullOrEmpty(horarioDeSaida, ErrorMessage.HorarioDeSaidaObrigatorio)
            );
        }
    }
}
