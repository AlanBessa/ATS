using ATS.Cadastro.Domain.Funcionarios.Interfaces.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System.Linq.Expressions;
using ATS.Cadastro.Infra.Data.Context;
using System.Data.Entity;
using System.Data;
using Dapper;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class CargoRepository : BaseRepository, ICargoRepository
    {
        private readonly CadastroContext _context;

        public CargoRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Cargo cargo)
        {
            _context.Cargos.Add(cargo);
        }

        public void Atualizar(Cargo cargo)
        {
            _context.Entry(cargo).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var cargo = _context.Cargos.Find(id);
            _context.Cargos.Remove(cargo);
        }
        
        public Cargo ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_CARGOS car " +
                          "WHERE car.IdCargo ='" + id + "'";

                var cargo = cn.Query<Cargo>(sql);

                return cargo.FirstOrDefault();
            };
        }

        public IEnumerable<Cargo> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_CARGOS car";

                var cargo = cn.Query<Cargo>(sql);

                return cargo;
            }
        }

        public IEnumerable<Cargo> Buscar(Expression<Func<Cargo, bool>> predicate)
        {
            return _context.Cargos.Where(predicate);
        }
    }
}
