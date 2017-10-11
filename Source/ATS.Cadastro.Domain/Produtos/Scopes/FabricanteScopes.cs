using ATS.Cadastro.Domain.Produtos.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Produtos.Scopes
{
    public static class FabricanteScopes
    {
        public static bool DefinirNomeFabricanteScopeEhValido(this Fabricante fabricante, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nome, ErrorMessage.NomeObrigatorio),
                AssertionConcern.AssertLength(nome, Fabricante.NomeMinLength, Fabricante.NomeMaxLength, ErrorMessage.NomeTamanhoInvalido)
            );
        }

        public static bool DefinirStatusFabricanteScopeEhValido(this Fabricante fabricante, string status)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(status, ErrorMessage.StatusObrigatorio),
                AssertionConcern.AssertLength(status, Fabricante.StatusMinLength, Fabricante.StatusMaxLength, ErrorMessage.StatusTamanhoInvalido)
            );
        }
    }
}
