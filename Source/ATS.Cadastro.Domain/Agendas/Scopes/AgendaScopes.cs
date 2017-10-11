using ATS.Cadastro.Domain.Agendas.Entidades;
using ATS.Core.Domain.Resources;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Agendas.Scopes
{
    public static class AgendaScopes
    {
        public static bool DefinirTituloAgendaScopeEhValido(this Agenda agenda, string titulo)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(titulo, ErrorMessage.TituloDaAgendaObrigatorio),
                AssertionConcern.AssertLength(titulo, Agenda.TituloMinLength, Agenda.TituloMaxLength, ErrorMessage.TituloDaAgendaTamanhoInvalido)
            );
        }

        public static bool DefinirStatusAgendaScopeEhValido(this Agenda agenda, string status)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(status, 0, Agenda.StatusMaxLength, ErrorMessage.StatusTamanhoInvalido)
            );
        }

        public static bool DefinirEmailAgendaScopeEhValido(this Agenda agenda, Email email)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(email.Endereco, Email.EnderecoMinLength, Email.EnderecoMaxLength, ErrorMessage.EmailTamanhoIncorreto),
                AssertionConcern.AssertNotNullOrEmpty(email.Endereco, ErrorMessage.EmailObrigatorio),
                AssertionConcern.AssertTrue(Email.IsValid(email.Endereco), ErrorMessage.EmailInvalido)
            );
        }
    }
}
