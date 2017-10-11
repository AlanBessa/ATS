using ATS.Cadastro.Domain.Funcionarios.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Funcionarios.Scopes
{
    public static class CargoScopes
    {
        public static bool DefinirNomeCargoScopeEhValido(this Cargo cargo, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nome, ErrorMessage.CTPSObrigatorio),
                AssertionConcern.AssertLength(nome, Cargo.NomeMinLength, Cargo.NomeMaxLength, ErrorMessage.NomeTamanhoInvalido)
            );
        }

        public static bool DefinirDescricaoCargoScopeEhValido(this Cargo cargo, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, ErrorMessage.DescricaoObrigatorio),
                AssertionConcern.AssertLength(descricao, Cargo.DescricaoMinLength, Cargo.DescricaoMaxLength, ErrorMessage.DescricaoTamanhoInvalido)
            );
        }
    }
}
