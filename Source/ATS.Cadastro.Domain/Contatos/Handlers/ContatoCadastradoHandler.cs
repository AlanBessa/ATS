using ATS.Cadastro.Domain.Contatos.Interfaces.Eventos;
using ATS.Core.Domain.Interfaces;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Contatos.Handlers
{
    public class ContatoCadastradoHandler : IHandler<ContatoCadastroEvent>
    {
        private List<ContatoCadastroEvent> _notifications;

        public List<ContatoCadastroEvent> GetValues()
        {
            return _notifications;
        }

        public void Handle(ContatoCadastroEvent args)
        {
            //Envia Email
        }

        public bool HasNotifications()
        {
            return GetValues().Count > 0;
        }

        public IEnumerable<ContatoCadastroEvent> Notify()
        {
            return GetValues();
        }

        public void Dispose()
        {
            _notifications = new List<ContatoCadastroEvent>();
        }
    }
}
