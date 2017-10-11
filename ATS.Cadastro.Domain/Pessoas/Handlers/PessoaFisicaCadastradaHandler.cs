using ATS.Cadastro.Domain.Pessoas.Events;
using ATS.Core.Domain.Interfaces;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Pessoas.Handlers
{
    public class PessoaFisicaCadastradaHandler : IHandler<PessoaFisicaCadastradaEvent>
    {
        private List<PessoaFisicaCadastradaEvent> _notifications;

        public PessoaFisicaCadastradaHandler()
        {
        }

        public void Handle(PessoaFisicaCadastradaEvent args)
        {
            // Envia Email!
        }

        public IEnumerable<PessoaFisicaCadastradaEvent> Notify()
        {
            return GetValues();
        }

        public bool HasNotifications()
        {
            return GetValues().Count > 0;
        }

        public List<PessoaFisicaCadastradaEvent> GetValues()
        {
            return _notifications;
        }

        public void Dispose()
        {
            _notifications = new List<PessoaFisicaCadastradaEvent>();
        }
    }
}
