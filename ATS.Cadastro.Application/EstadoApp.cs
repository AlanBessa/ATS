using ATS.Cadastro.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Services;
using ATS.Cadastro.Infra.Data.UoW;
using ATS.Cadastro.Application.Adapters;

namespace ATS.Cadastro.Application
{
    public class EstadoApp : BaseApp, IEstadoApp
    {
        private readonly IEstadoService _estadoService;

        public EstadoApp(IEstadoService estadoService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _estadoService = estadoService;
        }

        public IEnumerable<EstadoCommands> ObterTodosOsEstados()
        {
            var listaDeEstados = _estadoService.ObterTodos().ToList();

            var listaDeEstadosCommands = new List<EstadoCommands>();

            listaDeEstados.ForEach(m => listaDeEstadosCommands.Add(EstadoAdapter.ToModelDomain(m)));

            return listaDeEstadosCommands;
        }
    }
}
