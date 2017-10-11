using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Impostos.Scopes
{
    public static class TributacaoScopes
    {
        public static bool DefinirDescricaoTributacaoScopeEhValido(this Tributacao tributacao, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, ErrorMessage.DescricaoObrigatorio),
                AssertionConcern.AssertLength(descricao, Tributacao.DescricaoMinLength, Tributacao.DescricaoMaxLength, ErrorMessage.DescricaoTamanhoInvalido)
            );
        }
    }
}
