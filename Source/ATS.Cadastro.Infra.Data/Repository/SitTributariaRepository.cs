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
    public class SitTributariaRepository : BaseRepository, ISitTributariaRepository
    {
        private readonly CadastroContext _context;

        public SitTributariaRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(SitTributaria sitTributaria)
        {
            _context.SitTributarias.Add(sitTributaria);
        }

        public void Atualizar(SitTributaria sitTributaria)
        {
            _context.Entry(sitTributaria).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var sitTributaria = _context.SitTributarias.Find(id);
            _context.SitTributarias.Remove(sitTributaria);
        }

        public SitTributaria ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_SIT_TRIBUTARIA st " +
                          "WHERE st.IdSitTibutaria ='" + id + "'";

                var sitTributaria = cn.Query<SitTributaria>(sql);

                return sitTributaria.FirstOrDefault();
            }
        }

        public IEnumerable<SitTributaria> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_SIT_TRIBUTARIA st";

                var sitTributaria = cn.Query<SitTributaria>(sql);

                return sitTributaria;
            }
        }

        public IEnumerable<SitTributaria> Buscar(Expression<Func<SitTributaria, bool>> predicate)
        {
            return _context.SitTributarias.Where(predicate);
        }
    }
}
