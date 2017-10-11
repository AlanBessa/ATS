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
    public class MarcaRepository : BaseRepository, IMarcaRepository
    {
        private readonly CadastroContext _context;

        public MarcaRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Marca marca)
        {
            _context.Marcas.Add(marca);
        }

        public void Atualizar(Marca marca)
        {
            _context.Entry(marca).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var marca = _context.Marcas.Find(id);
            _context.Marcas.Remove(marca);
        }

        public Marca ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_MARCA mar " +
                          "WHERE c.IdMarca ='" + id + "'";

                var marca = cn.Query<Marca>(sql);

                return marca.FirstOrDefault();
            }
        }

        public IEnumerable<Marca> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_MARCA mar";

                var marca = cn.Query<Marca>(sql);

                return marca;
            }
        }

        public IEnumerable<Marca> Buscar(Expression<Func<Marca, bool>> predicate)
        {
            return _context.Marcas.Where(predicate);
        }
    }
}
