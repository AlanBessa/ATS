using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Services;
using System;
using System.Collections.Generic;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Repositories;
using System.Linq;

namespace ATS.Cadastro.Domain.Enderecos.Services
{
    public class CidadeService : BaseService, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public IEnumerable<Cidade> ObterTodasCidadesPor(Guid idEstado)
        {
            return _cidadeRepository.ObterTodasCidadesPor(idEstado).OrderBy(m => m.Nome);
        }
    }
}
