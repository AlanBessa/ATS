using ATS.Cadastro.Domain.Agendas.Scopes;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Core.Domain.ValueObjects;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Agendas.Entidades
{
    public class Agenda
    {
        #region "Constantes"

        public const int TituloMinLength = 6;
        public const int TituloMaxLength = 50;
        public const int StatusMaxLength = 10;

        #endregion

        private IList<Endereco> _enderecos;

        protected Agenda()
        {                        
        }

        public Agenda(string titulo, string descricao, string observacao, string status, string compromisso, 
            string email, DateTime? dataInicio, DateTime? dataFim, Endereco endereco, Guid? idAgenda)
        {
            IdAgenda = idAgenda == null ? Guid.NewGuid() : idAgenda.Value;

            DefinirTitulo(titulo);
            DefinirStatus(status);
            DefinirEmail(email);
            DefinirEndereco(endereco);

            Descricao = descricao;
            Observacao = observacao;
            Compromisso = compromisso;
            DataCadastro = DateTime.Now;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        #region "Propriedades"

        public Guid IdAgenda { get; private set; }                
        
        public string Titulo { get; private set; }
        
        public string Descricao { get; private set; }
        
        public string Observacao { get; private set; }
        
        public string Status { get; private set; }
        
        public string Compromisso { get; private set; }        
        
        public Email Email { get; private set; }
        
        public DateTime DataCadastro { get; private set; }
        
        public DateTime? DataAlteracao { get; set; }
        
        public DateTime? DataInicio { get; private set; }
        
        public DateTime? DataFim { get; private set; }        

        public ICollection<Endereco> ListaDeEnderecos
        {
            get { return _enderecos; }
            private set { _enderecos = new List<Endereco>(value); }
        }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Metodos"

        private void DefinirTitulo(string titulo)
        {
            if (!this.DefinirTituloAgendaScopeEhValido(titulo))
                return;

            Titulo = titulo;
        }

        private void DefinirStatus(string status)
        {
            if (string.IsNullOrEmpty(status)) return;

            if (!this.DefinirStatusAgendaScopeEhValido(status))
                return;

            Status = status;
        }

        private void DefinirEmail(string email)
        {            
            var tempEmail = new Email(email);

            if (!this.DefinirEmailAgendaScopeEhValido(tempEmail))
                return;

            Email = tempEmail;
        }

        public void DefinirEndereco(Endereco endereco)
        {
            if (endereco == null) return;

            _enderecos = new List<Endereco>();
            _enderecos.Add(endereco);
        }

        #endregion
    }
}
