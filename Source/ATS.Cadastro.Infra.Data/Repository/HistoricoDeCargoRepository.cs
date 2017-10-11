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
    public class HistoricoDeCargoRepository : BaseRepository, IHistoricoDeCargoRepository
    {
        private readonly CadastroContext _context;

        public HistoricoDeCargoRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(HistoricoDeCargo historicoDeCargo)
        {
            _context.HistoricosDeCargo.Add(historicoDeCargo);
        }

        public void Atualizar(HistoricoDeCargo historicoDeCargo)
        {
            _context.Entry(historicoDeCargo).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var historicoDeCargo = _context.HistoricosDeCargo.Find(id);
            _context.HistoricosDeCargo.Remove(historicoDeCargo);
        }

        public HistoricoDeCargo ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_HISTORICO_DE_CARGO hc " +
                          "WHERE hc.IdHistoricoDoCargo ='" + id + "'";

                var historicoDeCargo = cn.Query<HistoricoDeCargo>(sql);

                return historicoDeCargo.FirstOrDefault();
            }
        }

        public IEnumerable<HistoricoDeCargo> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_HISTORICO_DE_CARGO hc";

                var historicoDeCargo = cn.Query<HistoricoDeCargo>(sql);

                return historicoDeCargo;
            }
        }

        public IEnumerable<HistoricoDeCargo> Buscar(Expression<Func<HistoricoDeCargo, bool>> predicate)
        {
            return _context.HistoricosDeCargo.Where(predicate);
        }
    }
}
