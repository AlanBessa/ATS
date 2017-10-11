using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Contatos.Scopes
{
    public static class ContatoScopes
    {
        public static bool DefinirNomeScopeEhValido(this Contato contato, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nome, ErrorMessage.NomeObrigatorio),
                AssertionConcern.AssertLength(nome, Contato.NomeMinLength, Contato.NomeMaxLength, ErrorMessage.NomeTamanhoInvalido)
            );
        }

        public static bool DefinirPessoaContatoScopeEhValido(this Contato contato, PessoaJuridica pessoaJuridica)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(pessoaJuridica, ErrorMessage.PessoaJuridicaObrigatorio)
            );
        }

        public static bool DefinirEmailContatoScopeEhValido(this Contato contato, Email email)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(email.Endereco, Email.EnderecoMinLength, Email.EnderecoMaxLength, ErrorMessage.EmailTamanhoIncorreto),
                AssertionConcern.AssertTrue(Email.IsValid(email.Endereco), ErrorMessage.EmailInvalido)
            );
        }

        public static bool DefinirTelefoneContatoScopeEhValido(this Contato contato, Telefone telefone)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(telefone.Numero, Telefone.TelefoneMinLength, Telefone.TelefoneMaxLength, ErrorMessage.TelefoneTamanhoIncorreto),
                AssertionConcern.AssertTrue(Telefone.IsValid(telefone.Numero), ErrorMessage.TelefoneInvalido)
            );
        }
    }
}
