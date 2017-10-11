using ATS.Cadastro.Domain.Processo.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;

namespace ATS.Cadastro.Domain.Processo.Scopes
{
    public static class FornecedorPessoaJuridicaScopes
    {
        public static bool DefinirPessoaJuridicaFornecedorPJScopeEhValido(this FornecedorPessoaJuridica fornecedorPessoaJuridica, Guid? idPessoaJuridica)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idPessoaJuridica, ErrorMessage.PessoaJuridicaObrigatorio)
            );
        }
    }
}
