using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace ATS.Cadastro.Infra.CrossCutting.Identity.Configuracao
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Habilitar o envio de e-mail
            if (false)
            {
                // Injetar Servico de Email e utilizar
            }

            return Task.FromResult(0);
        }
    }
}
