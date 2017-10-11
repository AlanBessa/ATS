using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Impostos.Scopes
{
    public static class CofinsScopes
    {
        public static bool DefinirDescricaoCofinsScopeEhValido(this Cofins cofins, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, ErrorMessage.DescricaoObrigatorio),
                AssertionConcern.AssertLength(descricao, Cofins.DescricaoMinLength, Cofins.DescricaoMaxLength, ErrorMessage.DescricaoTamanhoInvalido)
            );
        }
    }
}
