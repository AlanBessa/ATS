using ATS.Cadastro.Domain.Impostos.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Impostos.Entidades;
using System.Linq.Expressions;
using ATS.Cadastro.Infra.Data.Context;
using System.Data.Entity;
using System.Data;
using Dapper;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class CofinsRepository : BaseRepository, ICofinsRepository
    {
        private readonly CadastroContext _context;

        public CofinsRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Cofins cofins)
        {
            _context.Cofinses.Add(cofins);
        }

        public void Atualizar(Cofins cofins)
        {
            _context.Entry(cofins).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var cofins = _context.Cofinses.Find(id);
            _context.Cofinses.Remove(cofins);
        }
        
        public Cofins ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_COFINS cof " +
                          "WHERE cof.IdCofins ='" + id + "'";

                var contato = cn.Query<Cofins>(sql);

                return contato.FirstOrDefault();
            }
        }

        public IEnumerable<Cofins> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_COFINS cof";

                var contato = cn.Query<Cofins>(sql);

                return contato;
            }
        }

        public IEnumerable<Cofins> Buscar(Expression<Func<Cofins, bool>> predicate)
        {
            return _context.Cofinses.Where(predicate);
        }
    }
}
