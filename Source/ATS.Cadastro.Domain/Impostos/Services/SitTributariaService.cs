using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Impostos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Cadastro.Domain.Impostos.Interfaces.Repositories;

namespace ATS.Cadastro.Domain.Impostos.Services
{
    public class SitTributariaService : BaseService, ISitTributariaService
    {
        private readonly ISitTributariaRepository _sitTributariaRepository;

        public SitTributariaService(ISitTributariaRepository sitTributariaRepository)
        {
            _sitTributariaRepository = sitTributariaRepository;
        }

        public void Adicionar(SitTributaria sitTributaria)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(SitTributaria sitTributaria)
        {
            throw new NotImplementedException();
        }
        
        public SitTributaria ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SitTributaria> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
