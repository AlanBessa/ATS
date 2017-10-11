using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Impostos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Cadastro.Domain.Impostos.Interfaces.Repositories;

namespace ATS.Cadastro.Domain.Impostos.Services
{
    public class CofinsService : BaseService, ICofinsService
    {
        private readonly ICofinsRepository _cofinsRepository;

        public CofinsService(ICofinsRepository cofinsRepository)
        {
            _cofinsRepository = cofinsRepository;
        }

        public void Adicionar(Cofins cofins)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Cofins cofins)
        {
            throw new NotImplementedException();
        }

        public Cofins ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cofins> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
