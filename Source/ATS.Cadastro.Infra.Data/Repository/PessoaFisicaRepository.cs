using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using System.Linq.Expressions;
using ATS.Cadastro.Infra.Data.Context;
using System.Data;
using Dapper;
using System.Data.Entity;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Core.Domain.ValueObjects;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using ATS.Core.Domain.Helpers;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class PessoaFisicaRepository : BaseRepository, IPessoaFisicaRepository
    {
        private readonly CadastroContext _context;

        public PessoaFisicaRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(PessoaFisica pessoaFisica)
        {
            _context.PessoasFisicas.Add(pessoaFisica);
        }

        public void Atualizar(PessoaFisica pessoaFisica)
        {
            _context.Entry(pessoaFisica).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var pessoaFisica = _context.PessoasFisicas.Find(id);
            _context.PessoasFisicas.Remove(pessoaFisica);
        }        

        public PessoaFisica ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                IniciarMapeamentoDapper();

                cn.Open();

                var sql = @"Select * From TB_PESSOA_FISICA pf
                            INNER JOIN TB_PESSOA p on pf.IdPessoa = p.IdPessoa WHERE pf.IdPessoa = @Id
                            Select CPF_Codigo From TB_PESSOA_FISICA WHERE IdPessoa = @Id                           
                            Select e.Cep_CepCod from TB_ENDERECO e
                            INNER JOIN TB_PESSOA_ENDERECO pe on e.IdEndereco = pe.IdEndereco
                            where pe.IdPessoa = @Id
                            ORDER BY e.IdEndereco
                            ";
                                
                var meiosDeComunicacao = cn.Query<MeioDeComunicacao, TipoDeMeioDeComunicacao, MeioDeComunicacao>(
                    @"Select * from TB_MEIO_COMUNICACAO mc
                      INNER JOIN TB_TIPO_MEIO_COMUNICACAO tmc on mc.TipoDeMeioDeComunicacaoId = tmc.IdTipoDeMeioDeComunicacao
                      where mc.PessoaId = @Id", 
                    (mc, tmc) => {
                        mc.DefinirTipoDeMeioDeComunicacao(tmc); 
                        return mc;
                    }, new { Id = id }, splitOn: "IdMeioDeComunicacao, IdTipoDeMeioDeComunicacao").ToList();
                
                var enderecos = cn.Query<Endereco, Cidade, Estado, Endereco>(
                    @"Select * from TB_ENDERECO e
                      INNER JOIN TB_PESSOA_ENDERECO pe on e.IdEndereco = pe.IdEndereco
                      INNER JOIN TB_CIDADE c on e.CidadeId = c.IdCidade
                      INNER JOIN TB_ESTADO est on e.EstadoId = est.IdEstado
                      where pe.IdPessoa = @Id
                      ORDER BY e.IdEndereco", 
                    (e, c, est) => {
                        e.DefinirCidade(c);
                        e.DefinirEstado(est);
                        return e;
                    }, new { Id = id }, splitOn: "IdEndereco, IdCidade, IdEstado").ToList();

                using (var multi = cn.QueryMultiple(sql, new { Id = id }))
                {
                    var pessoaFisica = multi.Read<PessoaFisica>().Single();
                    var cpf = multi.Read<string>().Single();
                    var listaCep = multi.Read<string>().ToList();
                    
                    for(var i = 0; i < enderecos.Count; i++)
                    {
                        enderecos[i].DefinirCep(listaCep[i]);

                        pessoaFisica.AdicionarEndereco(enderecos[i]);
                    }

                    pessoaFisica.DefinirCPF(cpf);
                    pessoaFisica.ListaDeMeioDeComunicacoes = meiosDeComunicacao;

                    return pessoaFisica;
                }                
            }
        }

        public IEnumerable<PessoaFisica> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TB_PESSOA_FISICA pf";

                var pessoaFisica = cn.Query<PessoaFisica>(sql);

                return pessoaFisica;
            }
        }

        public IEnumerable<PessoaFisica> Buscar(Expression<Func<PessoaFisica, bool>> predicate)
        {
            return _context.PessoasFisicas.Where(predicate);
        }

        public PessoaFisica ObterPorCPF(string cpf)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_PESSOA_FISICA pf 
                            WHERE pf.CPF_Codigo ='" + cpf + "'";

                var pessoaFisica = cn.Query<PessoaFisica>(sql);

                return pessoaFisica.FirstOrDefault();
            }
        }

        public PessoaFisica ObterPorRG(string rg)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TB_PESSOA_FISICA pf 
                            WHERE pf.RG ='" + rg + "'";

                var pessoaFisica = cn.Query<PessoaFisica>(sql);

                return pessoaFisica.FirstOrDefault();
            }
        }

        public IEnumerable<PessoaFisica> ObterTodosPorFiltro(string cpf, string nome)
        {
            var listaDePessoasFisica = new List<PessoaFisica>();
            
            var sql = @"Select p.IdPessoa, pf.Nome, pf.CPF_Codigo, pf.DataDeNascimento, 
                        pf.Sexo, pf.RG, pf.TituloEleitor, pf.NaturalidadeId, pf.Nacionalidade,
                        pf.EstadoCivil, p.Status 
                        from TB_PESSOA p
                        inner join TB_PESSOA_FISICA pf on p.IdPessoa = pf.IdPessoa
                        where 1=1";

            if (!string.IsNullOrEmpty(cpf)) sql += "and pf.CPF_Codigo = " + TextoHelper.GetNumeros(cpf);

            if (!string.IsNullOrEmpty(nome)) sql += "and pf.Nome Like '%" + nome + "%'";

            using (IDataReader reader = AdoConnection.ExecuteReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    var pessoaFisica = new PessoaFisica(reader["Nome"].ToString(), reader["CPF_Codigo"].ToString(), reader["RG"].ToString(), reader["TituloEleitor"].ToString(), 
                                                        Convert.ToDateTime(reader["DataDeNascimento"].ToString()), Guid.Parse(reader["NaturalidadeId"].ToString()), reader["Nacionalidade"].ToString(),
                                                        (ESexo)(Convert.ToInt32(reader["Sexo"].ToString())), (EEstadoCivil)(Convert.ToInt32(reader["EstadoCivil"].ToString())), reader["Status"].ToString(), 
                                                        Guid.Parse(reader["IdPessoa"].ToString()));

                    listaDePessoasFisica.Add(pessoaFisica);
                }
            }

            return listaDePessoasFisica;
        }
    }
}
