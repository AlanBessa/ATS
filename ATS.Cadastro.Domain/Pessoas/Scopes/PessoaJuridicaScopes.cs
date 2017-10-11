using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Pessoas.Scopes
{
    public static class PessoaJuridicaScopes
    {
        public static bool DefinirRazaoSocialPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, string razaoSocial)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(razaoSocial, ErrorMessage.RazaoSocialObrigatorio),
                AssertionConcern.AssertLength(razaoSocial, PessoaJuridica.TamanhoMinLength, PessoaJuridica.TamanhoMaxLength, ErrorMessage.RazaoSocialTamanhoInvalido)
            );
        }

        public static bool DefinirNomeFantasiaPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, string nomeFantasia)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nomeFantasia, ErrorMessage.NomeFantasiaObrigatorio),
                AssertionConcern.AssertLength(nomeFantasia, PessoaJuridica.TamanhoMinLength, PessoaJuridica.TamanhoMaxLength, ErrorMessage.NomeFantasiaTamanhoInvalido)
            );
        }

        public static bool DefinirCNPJPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, CNPJ cnpj)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertFixedLength(cnpj.Codigo, CNPJ.ValorMaxCnpj, ErrorMessage.CNPJTamanhoInvalido),
                AssertionConcern.AssertNotNullOrEmpty(cnpj.Codigo, ErrorMessage.CNPJObrigatorio),
                AssertionConcern.AssertTrue(CNPJ.Validar(cnpj.Codigo), ErrorMessage.CNPJInvalido)
            );
        }

        public static bool DefinirInscricaoPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, string inscricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(inscricao, ErrorMessage.InscricaoObrigatorio),
                AssertionConcern.AssertLength(inscricao, PessoaJuridica.TamanhoMinLength, PessoaJuridica.TamanhoMaxLength, ErrorMessage.InscricaoTamanhoInvalido)
            );
        }

        public static bool DefinirNomeDoSocioPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, Guid? idSocio)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idSocio, ErrorMessage.SocioInvalido)
            );
        }

        public static bool DefinirNomeDoSocioPessoaJuridicaScopeEhValido(this PessoaJuridica pessoaJuridica, PessoaFisica socio)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(socio, ErrorMessage.SocioInvalido)
            );
        }
    }
}
