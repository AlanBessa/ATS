using ATS.Cadastro.Domain.Produtos.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Produtos.Entidades
{
    public class Cor
    {
        #region "Constantes"

        public const int NomeMinLength = 3;
        public const int NomeMaxLength = 50;
        public const int StatusMinLength = 3;
        public const int StatusMaxLength = 10;

        #endregion

        protected Cor()
        {
        }

        public Cor(string nome, string status, string observacao, Guid? idCor)
        {
            IdCor = idCor == null ? Guid.NewGuid() : idCor.Value;

            DefinirNome(nome);
            DefinirStatus(status);
            Observacao = observacao;

            ListaDeProdutos = new List<Produto>();
        }

        #region "Propriedades"

        public Guid IdCor { get; private set; }
        
        public string Nome { get; private set; }
        
        public string Observacao { get; private set; }
        
        public string Status { get; private set; }

        public ICollection<Produto> ListaDeProdutos { get; private set; }

        #endregion

        #region "Métodos"

        private void DefinirNome(string nome)
        {
            if (!this.DefinirNomeCorsScopeEhValido(nome))
                return;

            Nome = nome;
        }

        public void DefinirStatus(string status)
        {
            if (!this.DefinirStatusCorsScopeEhValido(status))
                return;

            Status = status;
        }

        #endregion
    }
}
