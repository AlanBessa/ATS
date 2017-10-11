using ATS.Cadastro.Domain.Produtos.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Produtos.Scopes
{
    public static class TamanhoScopes
    {
        public static bool DefinirNomeTamanhoScopeEhValido(this Tamanho tamanho, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nome, ErrorMessage.NomeObrigatorio),
                AssertionConcern.AssertLength(nome, Tamanho.NomeMinLength, Tamanho.NomeMaxLength, ErrorMessage.NomeTamanhoInvalido)
            );
        }

        public static bool DefinirStatusTamanhoScopeEhValido(this Tamanho tamanho, string status)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(status, ErrorMessage.StatusObrigatorio),
                AssertionConcern.AssertLength(status, Tamanho.StatusMinLength, Tamanho.StatusMaxLength, ErrorMessage.StatusTamanhoInvalido)
            );
        }
    }
}
