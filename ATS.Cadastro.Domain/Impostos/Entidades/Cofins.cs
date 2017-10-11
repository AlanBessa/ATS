using ATS.Cadastro.Domain.Impostos.Scopes;
using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Impostos.Entidades
{
    public class Cofins
    {
        #region "Constantes"

        public const int DescricaoMinLength = 6;
        public const int DescricaoMaxLength = 200;

        #endregion

        protected Cofins()
        {

        }

        public Cofins(string codigoValor, string descricao)
        {
            IdCofins = Guid.NewGuid();

            DefinirValor(codigoValor);
            DefinirDescricao(descricao);

            ListaDeProdutos = new List<Produto>();
        }

        #region "Propriedades"

        public Guid IdCofins { get; private set; }

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
            if (!this.DefinirDescricaoCofinsScopeEhValido(descricao))
                return;

            Descricao = descricao;
        }

        #endregion    
    }
}
