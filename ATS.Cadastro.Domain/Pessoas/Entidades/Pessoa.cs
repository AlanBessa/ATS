using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Pessoas.Entidades
{
    public abstract class Pessoa
    {
        private IList<Endereco> _enderecos;

        protected Pessoa()
        {
            _enderecos = new List<Endereco>();
        }

        public Pessoa(string status, Guid? idPessoa)
        {
            IdPessoa = idPessoa == null ? Guid.NewGuid() : idPessoa.Value;

            Status = status;
            DataDeCadastro = DateTime.Now;
            Status = "ATIVO";

            _enderecos = new List<Endereco>();
            ListaDeMeioDeComunicacoes = new List<MeioDeComunicacao>();
        }

        #region "Propriedades"

        public Guid IdPessoa { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime? DataDeAlteracao { get; set; }

        public decimal LimiteDeCredito { get; set; }
        
        public string Referencias { get; set; }
        
        public string Conceito { get; set; }
        
        public string SPC { get; set; }

        public string Status { get; private set; }

        public string Observacao { get; set; }

        public DateTime? DataDaUltimaCompra { get; set; }

        public ICollection<Endereco> ListaDeEnderecos
        {
            get { return _enderecos; }
            private set { _enderecos = new List<Endereco>(value); }
        }        

        public ICollection<MeioDeComunicacao> ListaDeMeioDeComunicacoes { get; set; }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Métodos"

        public void AdicionarEndereco(Endereco endereco)
        {
            if (endereco == null) return;
            
            _enderecos.Add(endereco);
        }

        #endregion
    }
}
