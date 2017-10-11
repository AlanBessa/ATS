using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Impostos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Cadastro.Domain.Impostos.Interfaces.Repositories;

namespace ATS.Cadastro.Domain.Impostos.Services
{
    public class PisService : BaseService, IPisService
    {
        private readonly IPisRepository _pisRepository;

        public PisService(IPisRepository pisRepository)
        {
            _pisRepository = pisRepository;
        }

        public void Adicionar(Pis pis)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Pis pis)
        {
            throw new NotImplementedException();
        }

        public Pis ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pis> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
