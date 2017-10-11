using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;
using System;

namespace ATS.Cadastro.Domain.MeiosDeComunicacoes.Scopes
{
    public static class MeioDeComunicacaoScopes
    {
        public static bool DefinirPessoaMeioDeComunicacaoScopeEhValido(this MeioDeComunicacao meioDeComunicacao, Guid? idPessoa)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idPessoa, ErrorMessage.PessoaObrigatorio)
            );
        }

        public static bool DefinirTipoMeioDeComunicacaoMeioDeComunicacaoScopeEhValido(this MeioDeComunicacao meioDeComunicacao, Guid? idTipoDeMeioDeComunicacao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(idTipoDeMeioDeComunicacao, ErrorMessage.PessoaObrigatorio)
            );
        }

        public static bool DefinirTipoMeioDeComunicacaoMeioDeComunicacaoScopeEhValido(this MeioDeComunicacao meioDeComunicacao, TipoDeMeioDeComunicacao tipoDeMeioDeComunicacao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(tipoDeMeioDeComunicacao, ErrorMessage.PessoaObrigatorio)
            );
        }

        public static bool DefinirEmailMeioDeComunicacaoScopeEhValido(this MeioDeComunicacao meioDeComunicacao, Email email)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(email.Endereco, Email.EnderecoMinLength, Email.EnderecoMaxLength, ErrorMessage.EmailTamanhoIncorreto),
                AssertionConcern.AssertNotNullOrEmpty(email.Endereco, ErrorMessage.EmailObrigatorio),
                AssertionConcern.AssertTrue(Email.IsValid(email.Endereco), ErrorMessage.EmailInvalido)
            );
        }

        public static bool DefinirTelefoneMeioDeComunicacaoScopeEhValido(this MeioDeComunicacao meioDeComunicacao, Telefone telefone)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(telefone.Numero, Telefone.TelefoneMinLength, Telefone.TelefoneMaxLength, ErrorMessage.TelefoneTamanhoIncorreto),
                AssertionConcern.AssertNotNullOrEmpty(telefone.Numero, ErrorMessage.TelefoneObrigatorio),
                AssertionConcern.AssertTrue(Telefone.IsValid(telefone.Numero), ErrorMessage.TelefoneInvalido)
            );
        }

        public static bool DefinirRedeSocialMeioDeComunicacaoScopeEhValido(this MeioDeComunicacao meioDeComunicacao, string redeSocial)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(redeSocial, ErrorMessage.RedeSocialObrigatorio)
            );
        }

        public static bool DefinirSiteMeioDeComunicacaoScopeEhValido(this MeioDeComunicacao meioDeComunicacao, string site)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(site, ErrorMessage.SiteObrigatorio)
            );
        }
    }
}
