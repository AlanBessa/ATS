using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Processo.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Processo.Entidades
{
    public class FornecedorPessoaJuridica : Fornecedor
    {
        protected FornecedorPessoaJuridica()
        {
        }

        public FornecedorPessoaJuridica(Guid? idPessoaJuridica, Guid? idFornecedor)
            : base(idFornecedor)
        {
            DefinirPessoaJuridica(idPessoaJuridica);
        }

        #region "Propriedades"

        public Guid PessoaJuridicaId { get; private set; }

        public PessoaJuridica PessoaJuridica { get; private set; }

        #endregion

        #region "Metodos"

        private void DefinirPessoaJuridica(Guid? idPessoaJuridica)
        {
            if (!this.DefinirPessoaJuridicaFornecedorPJScopeEhValido(idPessoaJuridica))
                return;

            PessoaJuridicaId = idPessoaJuridica.Value;
        }

        #endregion
    }
}
