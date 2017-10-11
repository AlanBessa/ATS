using ATS.Cadastro.Domain.Enderecos.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using System.Linq.Expressions;
using ATS.Cadastro.Infra.Data.Context;
using System.Data.Entity;
using System.Data;
using Dapper;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        private readonly CadastroContext _context;

        public EnderecoRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public void Atualizar(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var endereco = _context.Enderecos.Find(id);
            _context.Enderecos.Remove(endereco);

            using (IDbConnection cn = Connection)
            {
                cn.Open();

                cn.Execute("Delete from TB_PESSOA_ENDERECO Where IdEndereco = @Id", new { Id = id });
            }
        }

        public Endereco ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                IniciarMapeamentoDapper();

                cn.Open();

                var sql = @"Select * From TB_ENDERECO e 
                            INNER JOIN TB_CIDADE c on e.CidadeId = c.IdCidade
                            INNER JOIN TB_ESTADO est on e.EstadoId = est.IdEstado
                            WHERE e.IdEndereco = @Id";

                var endereco = cn.Query<Endereco, Cidade, Estado, Endereco>(
                    sql,
                    (e, c, est) => {
                        e.DefinirCidade(c);
                        e.DefinirEstado(est);
                        return e;
                    }, new { Id = id }, splitOn: "IdEndereco, IdCidade, IdEstado").SingleOrDefault();

                var cep = cn.Query<string>("Select Cep_CepCod From TB_ENDERECO e WHERE e.IdEndereco = @Id", new { Id = id }).SingleOrDefault();

                endereco.DefinirCep(cep);

                return endereco;
            }
        }

        public IEnumerable<Endereco> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_ENDERECO e";

                var endereco = cn.Query<Endereco>(sql);

                return endereco;
            }
        }

        public IEnumerable<Endereco> Buscar(Expression<Func<Endereco, bool>> predicate)
        {
            return _context.Enderecos.Where(predicate);
        }        
    }
}
