using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Processo.Scopes;
using System;

namespace ATS.Cadastro.Domain.Processo.Entidades
{
    public class TransportadoraPessoaFisica : Transportadora
    {
        protected TransportadoraPessoaFisica()
        {
        }

        public TransportadoraPessoaFisica(Guid? idPessoaFisica, Guid? idTransportadora)
            : base(idTransportadora)
        {
            DefinirPessoaFisica(idPessoaFisica);
        }

        #region "Propriedade"

        public Guid PessoaFisicaId { get; private set; }

        public PessoaFisica PessoaFisica { get; private set; }

        #endregion

        #region "Metodo"

        private void DefinirPessoaFisica(Guid? idPessoaFisica)
        {
            if (!this.DefinirPessoaFisicaTrasnportadoraPFScopeEhValido(idPessoaFisica))
                return;

            PessoaFisicaId = idPessoaFisica.Value;
        }

        #endregion
    }
}
