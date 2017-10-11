using ATS.Cadastro.Domain.Impostos.Scopes;
using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Impostos.Entidades
{
    public class Tributacao
    {
        #region "Constantes"
        
        public const int DescricaoMinLength = 6;
        public const int DescricaoMaxLength = 200;

        #endregion

        protected Tributacao()
        {
        }

        public Tributacao(string codigoValor, string descricao)
        {
            IdTributacao = Guid.NewGuid();

            DefinirValor(codigoValor);
            DefinirDescricao(descricao);

            ListaDeProdutos = new List<Produto>();
        }

        #region "Propriedade"

        public Guid IdTributacao { get; private set; }

        public string CodValor { get; private set; }

        public string Descricao { get; private set; }

        public ICollection<Produto> ListaDeProdutos { get; private set; }

        #endregion

        #region "Metodos"

        private void DefinirValor(string valor)
        {
            //Verificar a necessidade de validação
            CodValor = valor;
        }

        private void DefinirDescricao(string descricao)
        {
            if (!this.DefinirDescricaoTributacaoScopeEhValido(descricao))
                return;

            Descricao = descricao;
        }

        #endregion        
    }
}
