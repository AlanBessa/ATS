using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;

namespace ATS.Cadastro.Domain.Pessoas.Scopes
{
    public static class PessoaFisicaScopes
    {
        public static bool DefinirNomeScopeEhValido(this PessoaFisica pessoaFisica, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nome, ErrorMessage.NomeObrigatorio),
                AssertionConcern.AssertLength(nome, PessoaFisica.NomeMinLength, PessoaFisica.NomeMaxLength, ErrorMessage.NomeTamanhoInvalido)
            );
        }

        public static bool DefinirCPFPessoaFisicaScopeEhValido(this PessoaFisica pessoaFisica, CPF cpf)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(cpf.Codigo, ErrorMessage.CPFObrigatorio),
                AssertionConcern.AssertFixedLength(cpf.Codigo, CPF.ValorMaxCpf, ErrorMessage.CPFTamanhoInvalido),                
                AssertionConcern.AssertTrue(CPF.Validar(cpf.Codigo), ErrorMessage.CPFInvalido)
            );
        }

        public static bool DefinirDataDeNascimentoPessoaFisicaScopeEhValido(this PessoaFisica pessoaFisica, DateTime? data)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertDateNotNull(data, ErrorMessage.DataDeNascimentoObrigatorio),
                AssertionConcern.AssertDateIsBiggerThan(data, DateTime.Now.AddYears(-150), ErrorMessage.DataDeNascimentoInvalido)
            );
        }

        public static bool DefinirNaturalidadePessoaFisicaScopeEhValido(this PessoaFisica pessoaFisica, Guid? naturalidadeId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(naturalidadeId, ErrorMessage.EstadoInvalido)
            );
        }
    }
}
