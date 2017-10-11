using ATS.Cadastro.Domain.Agendas.Interfaces.Repositories;
using ATS.Cadastro.Domain.Agendas.Interfaces.Services;
using ATS.Cadastro.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Cadastro.Domain.Agendas.Entidades;

namespace ATS.Cadastro.Domain.Agendas.Services
{
    public class AgendaService : BaseService, IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository enderecoRepository)
        {
            _agendaRepository = enderecoRepository;
        }

        public void Adicionar(Agenda agenda)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Agenda agenda)
        {
            throw new NotImplementedException();
        }

        public Agenda ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agenda> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
