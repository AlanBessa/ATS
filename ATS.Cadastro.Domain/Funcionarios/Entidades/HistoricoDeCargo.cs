using ATS.Cadastro.Domain.Funcionarios.Scopes;
using DomainValidation.Validation;
using System;

namespace ATS.Cadastro.Domain.Funcionarios.Entidades
{
    public class HistoricoDeCargo
    {
        protected HistoricoDeCargo()
        {
        }

        public HistoricoDeCargo(Cargo cargo, DateTime? dataDeAdmissao, Guid? funcionarioId, string horarioDeEntrada, string horarioDeSaida,
                                string horarioDeEntradaFimDeSemana, string horarioDeSaidaFimDeSemana, decimal salario, decimal comissao)
        {
            IdHistoricoDoCargo = Guid.NewGuid();
            DefinirCargo(cargo);
            DefinirDataDeAdmissao(dataDeAdmissao);
            DefinirFuncionario(funcionarioId);
            DefinirHorariosDeTrabalho(horarioDeEntrada, horarioDeSaida, horarioDeEntradaFimDeSemana, horarioDeSaidaFimDeSemana);
            Salario = salario;
            Comissao = comissao;
        }

        #region "Propriedades"

        public Guid IdHistoricoDoCargo { get; private set; }

        public Guid CargoId { get; private set; }

        public Cargo Cargo { get; private set; }

        public DateTime DataDeAdmissao { get; private set; }

        public DateTime DataDeDemissao { get; set; }

        public Guid FuncionarioId { get; private set; }

        public Funcionario Funcionario { get; private set; }

        public string HorarioDeEntrada { get; private set; }

        public string HorarioDeSaida { get; private set; }

        public string HorarioDeEntradaFimDeSemana { get; private set; }

        public string HorarioDeSaidaFimDeSemana { get; private set; }

        public decimal Comissao { get; private set; }

        public decimal Salario { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Métodos"

        private void DefinirCargo(Cargo cargo)
        {
            if (!this.AdicionarCargoScopeEhValido(cargo))
                return;

            Cargo = cargo;
        }

        private void DefinirDataDeAdmissao(DateTime? dataDeAdmissao)
        {
            if (!this.DefinirDataDeAdmissaoScopeEhValido(dataDeAdmissao))
                return;

            DataDeAdmissao = dataDeAdmissao.Value;
        }

        private void DefinirFuncionario(Guid? funcionarioId)
        {
            if (!this.DefinirFuncionarioScopeEhValido(funcionarioId))
                return;

            FuncionarioId = funcionarioId.Value;
        }

        private void DefinirHorariosDeTrabalho(string horarioDeEntrada, string horarioDeSaida,
            string horarioDeEntradaFimDeSemana, string horarioDeSaidaFimDeSemana)
        {
            HorarioDeEntradaFimDeSemana = horarioDeEntradaFimDeSemana;
            HorarioDeSaidaFimDeSemana = horarioDeSaidaFimDeSemana;

            if (!this.DefinirHorariosDeTrabalhoScopeEhValido(horarioDeEntrada, horarioDeSaida))
                return;

            HorarioDeEntrada = horarioDeEntrada;
            HorarioDeSaida = horarioDeSaida;
        }

        #endregion

    }
}
