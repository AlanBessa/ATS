using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Impostos.Scopes
{
    public static class SitTributariaScopes
    {
        public static bool DefinirDescricaoSitTributariaScopeEhValido(this SitTributaria sitTributaria, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, ErrorMessage.DescricaoObrigatorio),
                AssertionConcern.AssertLength(descricao, SitTributaria.DescricaoMinLength, SitTributaria.DescricaoMaxLength, ErrorMessage.DescricaoTamanhoInvalido)
            );
        }
    }
}
