using ATS.Cadastro.Domain.Produtos.Scopes;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Produtos.Entidades
{
    public class Marca
    {
        #region "Constantes"

        public const int NomeMinLength = 3;
        public const int NomeMaxLength = 50;
        public const int StatusMinLength = 3;
        public const int StatusMaxLength = 10;

        #endregion

        protected Marca()
        {
        }

        public Marca(string nome, string status, string observacao, Guid? idMarca)
        {
            IdMarca = idMarca == null ? Guid.NewGuid() : idMarca.Value;

            DefinirNome(nome);
            DefinirStatus(status);
            Observacao = observacao;

            ListaDeProdutos = new List<Produto>();
        }

        #region "Propriedades"

        public Guid IdMarca { get; private set; }
        
        public string Nome { get; private set; }
        
        public string Observacao { get; private set; }
        
        public string Status { get; private set; }

        public ICollection<Produto> ListaDeProdutos { get; private set; }

        #endregion

        #region "Métodos"

        private void DefinirNome(string nome)
        {
            if (!this.DefinirNomeMarcaScopeEhValido(nome))
                return;

            Nome = nome;
        }

        public void DefinirStatus(string status)
        {
            if (!this.DefinirStatusMarcaScopeEhValido(status))
                return;

            Status = status;
        }

        #endregion
    }
}
