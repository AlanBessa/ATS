using ATS.Cadastro.Domain.Produtos.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;

namespace ATS.Cadastro.Domain.Produtos.Scopes
{
    public static class TamanhoValorScopes
    {
        public static bool DefinirTamanhoTamanhoValorScopeEhValido(this TamanhoValor tamanhoValor, Guid? idTamanho)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idTamanho, ErrorMessage.TamanhoObrigatorio)
            );
        }
    }
}
