using ATS.Core.Domain.Events;
using ATS.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS.Presentation.WFA.Base
{
    public class BaseForm
    {
        public IHandler<DomainNotification> Notifications;

        public BaseForm()
        {
            this.Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
        }

        public bool ValidarErrosDominio()
        {
            if (!Notifications.HasNotifications()) return false;

            string messagem = string.Empty;

            foreach (var error in Notifications.GetValues())
            {
                messagem += error.Value + ". ";
            }

            MessageBox.Show(messagem);

            return true;
        }
    }
}
