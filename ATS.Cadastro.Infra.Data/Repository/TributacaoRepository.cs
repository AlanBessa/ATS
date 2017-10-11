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
    public class TributacaoRepository : BaseRepository, ITributacaoRepository
    {
        private readonly CadastroContext _context;

        public TributacaoRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Tributacao tributacao)
        {
            _context.Tributacoes.Add(tributacao);
        }

        public void Atualizar(Tributacao tributacao)
        {
            _context.Entry(tributacao).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var tributacao = _context.Tributacoes.Find(id);
            _context.Tributacoes.Remove(tributacao);
        }

        public Tributacao ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_TRIBUTACAO trib " +
                          "WHERE c.IdTributacao ='" + id + "'";

                var tributacao = cn.Query<Tributacao>(sql);

                return tributacao.FirstOrDefault();
            }
        }

        public IEnumerable<Tributacao> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_TRIBUTACAO trib";

                var tributacao = cn.Query<Tributacao>(sql);

                return tributacao;
            }
        }
        
        public IEnumerable<Tributacao> Buscar(Expression<Func<Tributacao, bool>> predicate)
        {
            return _context.Tributacoes.Where(predicate);
        }
    }
}
