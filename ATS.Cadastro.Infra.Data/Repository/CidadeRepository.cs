using ATS.Cadastro.Domain.Enderecos.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Infra.Data.Context;
using System.Data;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {
        private readonly CadastroContext _context;

        public CidadeRepository(CadastroContext context)
        {
            _context = context;
        }

        public IEnumerable<Cidade> ObterTodasCidadesPor(Guid idEstado)
        {
            var listaDeCidade = new List<Cidade>();

            var sql = @"select IdCidade, Nome, EstadoId from TB_CIDADE
                        where EstadoId = '" + idEstado + "'";
            
            using (IDataReader reader = AdoConnection.ExecuteReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    var cidade = new Cidade(reader["Nome"].ToString(), Guid.Parse(reader["EstadoId"].ToString()), Guid.Parse(reader["IdCidade"].ToString()));

                    listaDeCidade.Add(cidade);
                }
            }

            return listaDeCidade;
        }
    }
}
