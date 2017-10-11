using ATS.Core.Domain.Events;
using ATS.Core.Domain.Interfaces;
using ATS.Core.Domain.MessageController;
using ATS.Core.Domain.ValueObjects.Toast;

namespace ATS.Presentation.Web.Controllers
{
    public class BaseController : MessageControllerBase
    {
        public IHandler<DomainNotification> Notifications;

        public BaseController()
        {
            Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();            
        }
        
        public bool ValidarErrosDominio()
        {
            if (!Notifications.HasNotifications())
            {
                this.AddToastMessage("Sucesso", "Requesição salva com sucesso", ToastType.Success);
                return false;
            }

            foreach (var error in Notifications.GetValues())
            {
                this.AddToastMessage("Falha", error.Value, ToastType.Error);
            }

            return true;
        }        
    }
}