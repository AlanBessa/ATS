using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Processo.Entidades
{
    public abstract class Fornecedor
    {
        protected Fornecedor()
        {
        }

        public Fornecedor(Guid? idFornecedor)
        {
            IdFornecedor = idFornecedor == null ? Guid.NewGuid() : idFornecedor.Value;

            ListaDeProdutos = new List<Produto>();
            ListaDeEntradas = new List<Entrada>();
        }

        #region "Propriedades"

        public Guid IdFornecedor { get; set; }

        public ICollection<Produto> ListaDeProdutos { get; set; }

        public ICollection<Entrada> ListaDeEntradas { get; set; }

        #endregion

        #region "Metodos"

        #endregion
    }
}
