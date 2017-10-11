using ATS.Cadastro.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Services;
using ATS.Cadastro.Infra.Data.UoW;
using ATS.Cadastro.Application.Adapters;

namespace ATS.Cadastro.Application
{
    public class CidadeApp : BaseApp, ICidadeApp
    {
        private readonly ICidadeService _cidadeService;

        public CidadeApp(ICidadeService cidadeService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _cidadeService = cidadeService;
        }

        public IEnumerable<CidadeCommands> ObterTodasCidadesPor(Guid idEstado)
        {
            var listaDeCidades = _cidadeService.ObterTodasCidadesPor(idEstado).ToList();

            var listaDeCidadesCommands = new List<CidadeCommands>();

            listaDeCidades.ForEach(m => listaDeCidadesCommands.Add(CidadeAdapter.ToModelDomain(m)));

            return listaDeCidadesCommands;
        }
    }
}
