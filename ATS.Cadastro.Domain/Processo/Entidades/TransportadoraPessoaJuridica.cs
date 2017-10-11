using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Processo.Scopes;
using System;

namespace ATS.Cadastro.Domain.Processo.Entidades
{
    public class TransportadoraPessoaJuridica : Transportadora
    {
        protected TransportadoraPessoaJuridica()
        {
        }

        public TransportadoraPessoaJuridica(Guid? idPessoaJuridica, Guid? idTransportadora)
            : base(idTransportadora)
        {
            DefinirPessoaJuridica(idPessoaJuridica);
        }

        #region "Propriedade"

        public Guid PessoaJuridicaId { get; private set; }

        public PessoaJuridica PessoaJuridica { get; private set; }

        #endregion

        #region "Metodo"

        private void DefinirPessoaJuridica(Guid? idPessoaJuridica)
        {
            if (!this.DefinirPessoaJuridicaTransportadoraPJScopeEhValido(idPessoaJuridica))
                return;

            PessoaJuridicaId = idPessoaJuridica.Value;
        }

        #endregion
    }
}
