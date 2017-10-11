using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Impostos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Cadastro.Domain.Impostos.Interfaces.Repositories;

namespace ATS.Cadastro.Domain.Impostos.Services
{
    public class IpiService : BaseService, IIpiService
    {
        private readonly IIpiRepository _ipiRepository;

        public IpiService(IIpiRepository ipiRepository)
        {
            _ipiRepository = ipiRepository;
        }

        public void Adicionar(Ipi ipi)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Ipi ipi)
        {
            throw new NotImplementedException();
        }

        public Ipi ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ipi> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
