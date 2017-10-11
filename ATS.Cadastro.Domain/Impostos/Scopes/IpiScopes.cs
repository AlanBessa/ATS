using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Impostos.Scopes
{
    public static class IpiScopes
    {
        public static bool DefinirDescricaoIpiScopeEhValido(this Ipi ipi, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, ErrorMessage.DescricaoObrigatorio),
                AssertionConcern.AssertLength(descricao, Ipi.DescricaoMinLength, Ipi.DescricaoMaxLength, ErrorMessage.DescricaoTamanhoInvalido)
            );
        }
    }
}
