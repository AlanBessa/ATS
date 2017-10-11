using ATS.Core.Domain.Events;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Base
{
    public class BaseService
    {
        protected static bool PossuiConformidade(ValidationResult validationResult)
        {
            var notifications = validationResult.Erros.Select(validationError => new DomainNotification(validationError.ToString(), validationError.Message)).ToList();
            if (!notifications.Any()) return false;
            notifications.ToList().ForEach(DomainEvent.Raise);
            return true;
        }
    }
}
