using ATS.Cadastro.Domain.Pessoas.Handlers;
using ATS.Cadastro.Infra.Data.UoW;
using ATS.Core.Domain.Events;
using ATS.Core.Domain.Interfaces;

namespace ATS.Cadastro.Application
{
    public class BaseApp
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IHandler<DomainNotification> _notifications;
        protected PessoaFisicaCadastradaHandler PessoaFisicaCadastradaHandler;

        public BaseApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
            this.PessoaFisicaCadastradaHandler = DomainEvent.Container.GetInstance<PessoaFisicaCadastradaHandler>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}
