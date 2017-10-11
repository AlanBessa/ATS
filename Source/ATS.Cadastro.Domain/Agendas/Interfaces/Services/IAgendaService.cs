using ATS.Cadastro.Domain.Agendas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Agendas.Interfaces.Services
{
    public interface IAgendaService
    {
        void Adicionar(Agenda agenda);

        void Atualizar(Agenda agenda);

        void Remover(Guid id);

        Agenda ObterPorId(Guid id);

        IEnumerable<Agenda> ObterTodos();
    }
}
