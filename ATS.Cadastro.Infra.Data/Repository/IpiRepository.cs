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
    public class IpiRepository : BaseRepository, IIpiRepository
    {
        private readonly CadastroContext _context;

        public IpiRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Ipi ipi)
        {
            _context.Ipis.Add(ipi);
        }

        public void Atualizar(Ipi ipi)
        {
            _context.Entry(ipi).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var ipi = _context.Ipis.Find(id);
            _context.Ipis.Remove(ipi);
        }

        public Ipi ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_IPI ipi " +
                          "WHERE ipi.IdContato ='" + id + "'";

                var ipi = cn.Query<Ipi>(sql);

                return ipi.FirstOrDefault();
            }
        }

        public IEnumerable<Ipi> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_IPI ipi";

                var ipi = cn.Query<Ipi>(sql);

                return ipi;
            }
        }
        
        public IEnumerable<Ipi> Buscar(Expression<Func<Ipi, bool>> predicate)
        {
            return _context.Ipis.Where(predicate);
        }
    }
}
