using ATS.Cadastro.Domain.Contatos.Scopes;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.ValueObjects;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Contatos
{
    public class Contato
    {
        #region "Constantes"

        public const int NomeMinLength = 6;
        public const int NomeMaxLength = 200;

        #endregion

        private IList<Endereco> _enderecos;

        protected Contato()
        {
        }

        public Contato(string nome, string telefone, string email, PessoaJuridica pessoaJuridica, Endereco endereco)
        {
            IdContato = Guid.NewGuid();

            DefinirNome(nome);
            DefinirPessoaJuridica(pessoaJuridica);
            DefinirTelefone(telefone);
            DefinirEmail(email);
            DefinirEndereco(endereco);
        }

        #region "Propriedades"

        public Guid IdContato { get; private set; }

        public string Nome { get; private set; }

        public string Observacao { get; set; }

        public Email Email { get; set; }

        public Telefone Telefone { get; set; }

        public Guid PessoaJuridicaId { get; private set; }

        public PessoaJuridica PessoaJuridica { get; private set; }

        public ICollection<Endereco> ListaDeEnderecos
        {
            get { return _enderecos; }
            private set { _enderecos = new List<Endereco>(value); }
        }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Métodos"

        private void DefinirNome(string nome)
        {
            if (!this.DefinirNomeScopeEhValido(nome))
                return;

            Nome = nome;
        }

        private void DefinirPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            if (!this.DefinirPessoaContatoScopeEhValido(pessoaJuridica))
                return;

            PessoaJuridica = pessoaJuridica;
        }
        
        public void DefinirEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return;

            var tempEmail = new Email(email);

            if (!this.DefinirEmailContatoScopeEhValido(tempEmail))
                return;

            Email = tempEmail;
        }

        public void DefinirTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone)) return;

            var tempTelefone = new Telefone(telefone);

            if (!this.DefinirTelefoneContatoScopeEhValido(tempTelefone))
                return;

            Telefone = tempTelefone;
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
