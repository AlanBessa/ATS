using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Services;
using System.Collections.Generic;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Repositories;
using System.Linq;

namespace ATS.Cadastro.Domain.Enderecos.Services
{
    public class EstadoService : BaseService, IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        public IEnumerable<Estado> ObterTodos()
        {
            return _estadoRepository.ObterTodos().OrderBy(m => m.Nome);
        }
    }
}
