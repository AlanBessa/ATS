using ATS.Cadastro.Domain.Produtos.Scopes;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Produtos.Entidades
{
    public class TamanhoValor
    {
        protected TamanhoValor()
        {
        }

        public TamanhoValor(decimal valor, Guid? idTamanho, Guid? idTamanhoValor)
        {
            IdTamanhoValor = idTamanhoValor == null ? Guid.NewGuid() : idTamanhoValor.Value;
            Valor = valor;
            
            DefinirTamanho(idTamanho);

            ListaDeItensProduto = new List<ItemProduto>();
        }

        #region "Propriedades"

        public Guid IdTamanhoValor { get; private set; }

        public decimal Valor { get; private set; }

        public ICollection<ItemProduto> ListaDeItensProduto { get; private set; }

        public Guid TamanhoId { get; private set; }

        public Tamanho Tamanho { get; private set; }

        #endregion

        #region "Métodos"
        
        private void DefinirTamanho(Guid? idTamanho)
        {
            if (!this.DefinirTamanhoTamanhoValorScopeEhValido(idTamanho))
                return;

            TamanhoId = idTamanho.Value;
        }

    #endregion
}
}
