using ATS.Cadastro.Domain.Produtos.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Produtos.Scopes
{
    public static class CorScopes
    {
        public static bool DefinirNomeCorsScopeEhValido(this Cor cor, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nome, ErrorMessage.NomeObrigatorio),
                AssertionConcern.AssertLength(nome, Cor.NomeMinLength, Cor.NomeMaxLength, ErrorMessage.NomeTamanhoInvalido)
            );
        }

        public static bool DefinirStatusCorsScopeEhValido(this Cor cor, string status)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(status, ErrorMessage.StatusObrigatorio),
                AssertionConcern.AssertLength(status, Cor.StatusMinLength, Cor.StatusMaxLength, ErrorMessage.StatusTamanhoInvalido)
            );
        }
    }
}
