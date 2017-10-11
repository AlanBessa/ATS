using ATS.Cadastro.Domain.Produtos.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Produtos.Scopes
{
    public static class MarcaScopes
    {
        public static bool DefinirNomeMarcaScopeEhValido(this Marca marca, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nome, ErrorMessage.NomeObrigatorio),
                AssertionConcern.AssertLength(nome, Marca.NomeMinLength, Marca.NomeMaxLength, ErrorMessage.NomeTamanhoInvalido)
            );
        }

        public static bool DefinirStatusMarcaScopeEhValido(this Marca marca, string status)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(status, ErrorMessage.StatusObrigatorio),
                AssertionConcern.AssertLength(status, Marca.StatusMinLength, Marca.StatusMaxLength, ErrorMessage.StatusTamanhoInvalido)
            );
        }
    }
}
