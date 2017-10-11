using ATS.Core.Domain.ValueObjects.Toast;
using System.Web.Mvc;

namespace ATS.Core.Domain.MessageController
{
    public abstract class MessageControllerBase : Controller
    {
        public MessageControllerBase()
        {
            Toastr = new Toastr();
        }

        public Toastr Toastr { get; set; }

        protected ToastMessage AddToastMessage(string title, string message, ToastType toastType)
        {
            return Toastr.AddToastMessage(title, message, toastType);
        }
    }
}
