using ATS.Cadastro.Domain.Produtos.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Produtos.Entidades;
using System.Linq.Expressions;
using ATS.Cadastro.Infra.Data.Context;
using System.Data.Entity;
using System.Data;
using Dapper;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class CorRepository : BaseRepository, ICorRepository
    {
        private readonly CadastroContext _context;

        public CorRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Cor cor)
        {
            _context.Cores.Add(cor);
        }

        public void Atualizar(Cor cor)
        {
            _context.Entry(cor).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var cor = _context.Cores.Find(id);
            _context.Cores.Remove(cor);
        }

        public Cor ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_COR cor " +
                          "WHERE cor.IdCor ='" + id + "'";

                var cor = cn.Query<Cor>(sql);

                return cor.FirstOrDefault();
            }
        }

        public IEnumerable<Cor> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_COR cor";

                var cor = cn.Query<Cor>(sql);

                return cor;
            }
        }
        
        public IEnumerable<Cor> Buscar(Expression<Func<Cor, bool>> predicate)
        {
            return _context.Cores.Where(predicate);
        }
    }
}
