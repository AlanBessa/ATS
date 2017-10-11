using ATS.Cadastro.Domain.Contatos.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Contatos;
using System.Linq.Expressions;
using ATS.Cadastro.Infra.Data.Context;
using System.Data;
using Dapper;
using System.Data.Entity;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class ContatoRepository : BaseRepository, IContatoRepository
    {
        private readonly CadastroContext _context;

        public ContatoRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Contato contato)
        {
            _context.Contatos.Add(contato);
        }

        public void Atualizar(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var contato = _context.Contatos.Find(id);
            _context.Contatos.Remove(contato);
        }               

        public Contato ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_CONTATO c " +
                          "WHERE c.IdContato ='" + id + "'";

                var contato = cn.Query<Contato>(sql);

                return contato.FirstOrDefault();
            }
        }

        public IEnumerable<Contato> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_CONTATO c";

                var contato = cn.Query<Contato>(sql);

                return contato;
            }
        }

        public IEnumerable<Contato> Buscar(Expression<Func<Contato, bool>> predicate)
        {
            return _context.Contatos.Where(predicate);
        }
    }
}
