using ATS.Cadastro.Domain.Funcionarios.Scopes;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;
using DomainValidation.Validation;

namespace ATS.Cadastro.Domain.Funcionarios.Entidades
{
    public class Funcionario : PessoaFisica
    {
        private IList<HistoricoDeCargo> _historicoDeCargos;

        protected Funcionario()
        {

        }

        public Funcionario(string ctps)
        {
            DefinirCTPS(ctps);
            ListaDeHistoricoDeCargos = new List<HistoricoDeCargo>();
        }

        #region "Propriedades"

        public string CTPS { get; private set; }

        public DateTime DataDaProximaFerias { get; set; }

        public ICollection<HistoricoDeCargo> ListaDeHistoricoDeCargos
        {
            get { return _historicoDeCargos; }
            private set { _historicoDeCargos = new List<HistoricoDeCargo>(value); }
        }
        
        #endregion

        #region "Métodos"

        private void DefinirCTPS(string ctps)
        {
            if (!this.DefinirCTPSFuncionarioScopeEhValido(ctps))
                return;

            CTPS = ctps;
        }

        public void DefinirCargoNoHistorico(IList<HistoricoDeCargo> historicoDeCargo)
        {
            if (historicoDeCargo == null || !historicoDeCargo.Any()) return;

            _historicoDeCargos = new List<HistoricoDeCargo>();
            historicoDeCargo.ToList().ForEach(m => AdicionarCargoNoHistorico(m));
        }

        public void AdicionarCargoNoHistorico(HistoricoDeCargo historicoDeCargo)
        {
            //Ver se haverá necessidade de validação aqui
            _historicoDeCargos.Add(historicoDeCargo);
        }

        #endregion
    }
}
