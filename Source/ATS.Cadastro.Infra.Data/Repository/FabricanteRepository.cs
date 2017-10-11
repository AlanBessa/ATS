using ATS.Cadastro.Domain.Produtos.Interfaces.Repositories;
using ATS.Cadastro.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Produtos.Entidades;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data;
using Dapper;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class FabricanteRepository : BaseRepository, IFabricanteRepository
    {
        private readonly CadastroContext _context;

        public FabricanteRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Fabricante fabricante)
        {
            _context.Fabricantes.Add(fabricante);
        }

        public void Atualizar(Fabricante fabricante)
        {
            _context.Entry(fabricante).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var fabricante = _context.Fabricantes.Find(id);
            _context.Fabricantes.Remove(fabricante);
        }

        public Fabricante ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_FABRICANTE fab " +
                          "WHERE fab.IdFabricante ='" + id + "'";

                var fabricante = cn.Query<Fabricante>(sql);

                return fabricante.FirstOrDefault();
            }
        }

        public IEnumerable<Fabricante> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_FABRICANTE fab";

                var fabricante = cn.Query<Fabricante>(sql);

                return fabricante;
            }
        }
        
        public IEnumerable<Fabricante> Buscar(Expression<Func<Fabricante, bool>> predicate)
        {
            return _context.Fabricantes.Where(predicate);
        }
    }
}
