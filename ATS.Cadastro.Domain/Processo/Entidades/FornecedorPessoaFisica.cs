using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Processo.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Processo.Entidades
{
    public class FornecedorPessoaFisica : Fornecedor
    {
        protected FornecedorPessoaFisica()
        {
        }

        public FornecedorPessoaFisica(Guid? idPessoaFisica, Guid? idFornecedor)
            : base(idFornecedor)
        {
            DefinirPessoaFisica(idPessoaFisica);
        }

        #region "Propriedades"

        public Guid PessoaFisicaId { get; private set; }

        public PessoaFisica PessoaFisica { get; private set; }

        #endregion

        #region "Metodos"

        private void DefinirPessoaFisica(Guid? idPessoaFisica)
        {
            if (!this.DefinirPessoaFisicaFornecedorPFScopeEhValido(idPessoaFisica))
                return;

            PessoaFisicaId = idPessoaFisica.Value;
        }

        #endregion
    }
}
