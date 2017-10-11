using ATS.Cadastro.Domain.Funcionarios.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Funcionarios.Scopes
{
    public static class FuncionarioScopes
    {
        public static bool DefinirCTPSFuncionarioScopeEhValido(this Funcionario funcionario, string ctps)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(ctps, ErrorMessage.CTPSObrigatorio)
            );
        }

    }
}
