using ATS.Cadastro.Domain.Processo.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Processo.Scopes
{
    public static class TransportadoraPessoaJuridicaScopes
    {
        public static bool DefinirPessoaJuridicaTransportadoraPJScopeEhValido(this TransportadoraPessoaJuridica transportadoraPessoaJuridica, Guid? idPessoaJuridica)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idPessoaJuridica, ErrorMessage.PessoaJuridicaObrigatorio)
            );
        }
    }
}
