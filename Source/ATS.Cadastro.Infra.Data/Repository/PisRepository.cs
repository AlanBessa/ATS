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
    public class PisRepository : BaseRepository, IPisRepository
    {
        private readonly CadastroContext _context;

        public PisRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Pis pis)
        {
            _context.Pises.Add(pis);
        }

        public void Atualizar(Pis pis)
        {
            _context.Entry(pis).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var pis = _context.Pises.Find(id);
            _context.Pises.Remove(pis);
        }
        
        public Pis ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_PIS pis " +
                          "WHERE c.IdPis ='" + id + "'";

                var contato = cn.Query<Pis>(sql);

                return contato.FirstOrDefault();
            }
        }

        public IEnumerable<Pis> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_PIS pis";

                var contato = cn.Query<Pis>(sql);

                return contato;
            }
        }

        public IEnumerable<Pis> Buscar(Expression<Func<Pis, bool>> predicate)
        {
            return _context.Pises.Where(predicate);
        }
    }
}
