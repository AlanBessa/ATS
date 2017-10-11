using ATS.Cadastro.Domain.Produtos.Scopes;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Produtos.Entidades
{
    public class Tamanho
    {
        #region "Constantes"

        public const int NomeMinLength = 3;
        public const int NomeMaxLength = 50;
        public const int StatusMinLength = 3;
        public const int StatusMaxLength = 10;

        #endregion

        protected Tamanho()
        {

        }

        public Tamanho(string nome, string status, string observacao, Guid? idTamanho)
        {
            IdTamanho = idTamanho == null ? Guid.NewGuid() : idTamanho.Value;

            DefinirNome(nome);
            DefinirStatus(status);

            Observacao = observacao;
        }

        #region "Propriedades"

        public Guid IdTamanho { get; private set; }
                
        public string Nome { get; private set; }
        
        public string Observacao { get; private set; }
        
        public string Status { get; private set; }

        public ICollection<TamanhoValor> ListaDeTamanhoValores { get; private set; }

        #endregion

        #region "Métodos"

        private void DefinirNome(string nome)
        {
            if (!this.DefinirNomeTamanhoScopeEhValido(nome))
                return;

            Nome = nome;
        }

        private void DefinirStatus(string status)
        {
            if (!this.DefinirStatusTamanhoScopeEhValido(status))
                return;

            Status = status;
        }

        #endregion
    }
}
