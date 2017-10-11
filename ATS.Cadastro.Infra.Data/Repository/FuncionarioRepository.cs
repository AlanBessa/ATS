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
    public class FuncionarioRepository : BaseRepository, IFuncionarioRepository
    {
        private readonly CadastroContext _context;

        public FuncionarioRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
        }

        public void Atualizar(Funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            _context.Funcionarios.Remove(funcionario);
        }

        public Funcionario ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                //Falta completar a query

                var sql = @"Select * From TB_FUNCIONARIO f " +
                          "WHERE c.IdPessoa ='" + id + "'";

                var funcionario = cn.Query<Funcionario>(sql);

                return funcionario.FirstOrDefault();
            }
        }

        public IEnumerable<Funcionario> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_FUNCIONARIO f";

                var funcionario = cn.Query<Funcionario>(sql);

                return funcionario;
            }
        }

        public IEnumerable<Funcionario> Buscar(Expression<Func<Funcionario, bool>> predicate)
        {
            return _context.Funcionarios.Where(predicate);
        }
    }
}
