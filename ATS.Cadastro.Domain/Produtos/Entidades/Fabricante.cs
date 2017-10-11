using ATS.Cadastro.Domain.Produtos.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Produtos.Entidades
{
    public class Fabricante
    {
        #region "Constantes"

        public const int NomeMinLength = 3;
        public const int NomeMaxLength = 50;
        public const int StatusMinLength = 3;
        public const int StatusMaxLength = 10;

        #endregion

        protected Fabricante()
        {
        }

        public Fabricante(string nome, string status, string observacao, Guid? idFabricante)
        {
            IdFabricante = idFabricante == null ? Guid.NewGuid() : idFabricante.Value;

            DefinirNome(nome);
            DefinirStatus(status);
            Observacao = observacao;

            ListaDeProdutos = new List<Produto>();
        }

        #region "Propriedades"

        public Guid IdFabricante { get; private set; }
        
        public string Nome { get; private set; }
        
        public string Observacao { get; private set; }
        
        public string Status { get; private set; }

        public ICollection<Produto> ListaDeProdutos { get; private set; }

        #endregion

        #region "Métodos"

        private void DefinirNome(string nome)
        {
            if (!this.DefinirNomeFabricanteScopeEhValido(nome))
                return;

            Nome = nome;
        }

        public void DefinirStatus(string status)
        {
            if (!this.DefinirStatusFabricanteScopeEhValido(status))
                return;

            Status = status;
        }

        #endregion
    }
}
