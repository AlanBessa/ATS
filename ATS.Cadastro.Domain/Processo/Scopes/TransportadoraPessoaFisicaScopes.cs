using ATS.Cadastro.Domain.Processo.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;

namespace ATS.Cadastro.Domain.Processo.Scopes
{
    public static class TransportadoraPessoaFisicaScopes
    {
        public static bool DefinirPessoaFisicaTrasnportadoraPFScopeEhValido(this TransportadoraPessoaFisica transportadoraPessoaFisica, Guid? idPessoaFisica)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idPessoaFisica, ErrorMessage.PessoaFisicaObrigatorio)
            );
        }
    }
}
