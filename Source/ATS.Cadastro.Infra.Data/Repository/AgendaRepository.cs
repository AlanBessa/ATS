using ATS.Cadastro.Domain.Agendas.Interfaces.Repositories;
using ATS.Cadastro.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Agendas.Entidades;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data;
using Dapper;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class AgendaRepository : BaseRepository, IAgendaRepository
    {
        private readonly CadastroContext _context;

        public AgendaRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Agenda agenda)
        {
            _context.Agendas.Add(agenda);
        }

        public void Atualizar(Agenda agenda)
        {
            _context.Entry(agenda).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var agenda = _context.Agendas.Find(id);
            _context.Agendas.Remove(agenda);
        }

        public Agenda ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_AGENDA ag " +
                          "WHERE ag.IdAgenda ='" + id + "'";

                var agenda = cn.Query<Agenda>(sql);

                return agenda.FirstOrDefault();
            }
        }

        public IEnumerable<Agenda> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_AGENDA ag";

                var agenda = cn.Query<Agenda>(sql);

                return agenda;
            }
        }
        
        public IEnumerable<Agenda> Buscar(Expression<Func<Agenda, bool>> predicate)
        {
            return _context.Agendas.Where(predicate);
        }
    }
}
