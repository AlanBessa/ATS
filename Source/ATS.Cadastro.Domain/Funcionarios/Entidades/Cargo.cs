using ATS.Cadastro.Domain.Funcionarios.Scopes;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Funcionarios.Entidades
{
    public class Cargo
    {
        #region "Constantes"

        public const int NomeMinLength = 6;
        public const int NomeMaxLength = 80;
        public const int DescricaoMinLength = 6;
        public const int DescricaoMaxLength = 200;

        #endregion

        protected Cargo()
        {
        }

        public Cargo(string nome, string descricao)
        {
            IdCargo = Guid.NewGuid();
            ListaDeHistoricosDeCargo = new List<HistoricoDeCargo>();

            DefinirNome(nome);
            DefinirDescricao(descricao);
        }

        #region "Propriedades"

        public Guid IdCargo { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public ICollection<HistoricoDeCargo> ListaDeHistoricosDeCargo { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Métodos"

        private void DefinirNome(string nome)
        {
            if (!this.DefinirNomeCargoScopeEhValido(nome))
                return;

            Nome = nome;
        }

        private void DefinirDescricao(string descricao)
        {
            if (!this.DefinirDescricaoCargoScopeEhValido(descricao))
                return;

            Descricao = descricao;
        }

        #endregion
    }
}
