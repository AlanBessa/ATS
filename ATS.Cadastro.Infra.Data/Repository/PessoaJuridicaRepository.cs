using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using System.Linq.Expressions;
using ATS.Cadastro.Infra.Data.Context;
using System.Data.Entity;
using System.Data;
using Dapper;
using ATS.Core.Domain.Helpers;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using ATS.Cadastro.Domain.Enderecos.Entidades;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class PessoaJuridicaRepository : BaseRepository, IPessoaJuridicaRepository
    {
        private readonly CadastroContext _context;

        public PessoaJuridicaRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(PessoaJuridica pessoaJuridica)
        {
            _context.PessoasJuridicas.Add(pessoaJuridica);
        }

        public void Atualizar(PessoaJuridica pessoaJuridica)
        {
            _context.Entry(pessoaJuridica).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var pessoaJuridica = _context.PessoasJuridicas.Find(id);
            _context.PessoasJuridicas.Remove(pessoaJuridica);
        }

        public PessoaJuridica ObterPorId(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                IniciarMapeamentoDapper();

                cn.Open();

                var sql = @"Select * From TB_PESSOA_JURIDICA pj
                            INNER JOIN TB_PESSOA p on pj.IdPessoa = p.IdPessoa WHERE pj.IdPessoa = @Id
                            Select CNPJ_Codigo From TB_PESSOA_JURIDICA WHERE IdPessoa = @Id                           
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
                    var pessoaJuridica = multi.Read<PessoaJuridica>().Single();
                    var cnpj = multi.Read<string>().Single();
                    var listaCep = multi.Read<string>().ToList();

                    for (var i = 0; i < enderecos.Count; i++)
                    {
                        enderecos[i].DefinirCep(listaCep[i]);

                        pessoaJuridica.AdicionarEndereco(enderecos[i]);
                    }

                    //Adicionar Contato

                    pessoaJuridica.DefinirCNPJ(cnpj);
                    pessoaJuridica.ListaDeMeioDeComunicacoes = meiosDeComunicacao;

                    return pessoaJuridica;
                }
            }
        }

        public IEnumerable<PessoaJuridica> ObterTodos()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                //Necessita completar a query

                var sql = @"SELECT * FROM TB_PESSOA_JURIDICA pj";

                var pessoaJuridica = cn.Query<PessoaJuridica>(sql);

                return pessoaJuridica;
            }
        }

        public IEnumerable<PessoaJuridica> Buscar(Expression<Func<PessoaJuridica, bool>> predicate)
        {
            return _context.PessoasJuridicas.Where(predicate);
        }

        public PessoaJuridica ObterPorCNPJ(string cnpj)
        {
            return Buscar(m => m.CNPJ.Codigo.Equals(cnpj)).FirstOrDefault();
        }

        public IEnumerable<PessoaJuridica> ObterTodosPorFiltro(string cnpj, string razaoSocial)
        {      
            using (IDbConnection cn = Connection)
            {
                IniciarMapeamentoDapper();

                cn.Open();
                
                var sql = @"SELECT *
                            FROM TB_PESSOA p
                            INNER JOIN TB_PESSOA_JURIDICA pj on p.IdPessoa = pj.IdPessoa
                            INNER JOIN TB_PESSOA_FISICA pfsp on pj.SocioId = pfsp.IdPessoa
                            LEFT JOIN TB_PESSOA_FISICA pfss on pj.SocioMenorId = pfsp.IdPessoa
                            where 1=1";

                var sqlCnpj = @"SELECT CNPJ_Codigo
                                FROM TB_PESSOA p
                                INNER JOIN TB_PESSOA_JURIDICA pj on p.IdPessoa = pj.IdPessoa
                                INNER JOIN TB_PESSOA_FISICA pfsp on pj.SocioId = pfsp.IdPessoa
                                LEFT JOIN TB_PESSOA_FISICA pfss on pj.SocioMenorId = pfsp.IdPessoa
                                where 1=1";

                if (!string.IsNullOrEmpty(cnpj))
                {
                    var paramsCNPJ = " and pj.CNPJ_Codigo = " + TextoHelper.GetNumeros(cnpj);

                    sql += paramsCNPJ;
                    sqlCnpj += paramsCNPJ;
                }

                if (!string.IsNullOrEmpty(razaoSocial))
                {
                    var paramsRazaoSocial = " and pj.RazaoSocial Like '%" + razaoSocial + "%'";

                    sql += paramsRazaoSocial;
                    sqlCnpj += paramsRazaoSocial;
                }
                var orderBy = " ORDER BY p.IdPessoa";

                sql += orderBy;
                sqlCnpj += orderBy;

                var pessoasJuridicas = cn.Query<PessoaJuridica, PessoaFisica, PessoaFisica, PessoaJuridica>(
                    sql,
                    (pj, pfsp, pfss) => {
                        pj.DefinirSocioPrincipal(pfsp);
                        pj.DefinirSocioSecundario(pfss);
                        return pj;
                    }, null, splitOn: "IdPessoa, IdPessoa, IdPessoa").ToList();

                using (var multi = cn.QueryMultiple(sqlCnpj))
                {
                    var listaCnpj = multi.Read<string>().ToList();

                    for (var i = 0; i < pessoasJuridicas.Count; i++)
                    {
                        pessoasJuridicas[i].DefinirCNPJ(listaCnpj[i]);
                    }
                }

                return pessoasJuridicas;
            }            
        }
    }
}
