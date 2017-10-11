using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Repositories;
using ATS.Cadastro.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class MeioDeComunicacaoRepository : BaseRepository, IMeioDeComunicacaoRepository
    {
        private readonly CadastroContext _context;

        public MeioDeComunicacaoRepository(CadastroContext context)
        {
            _context = context;
        }

        public void Adicionar(MeioDeComunicacao meioDeComunicacao)
        {
            _context.MeiosDeComunicacao.Add(meioDeComunicacao);
        }

        public void Atualizar(MeioDeComunicacao meioDeComunicacao)
        {
            _context.Entry(meioDeComunicacao).State = EntityState.Modified;
        }

        public void Remover(Guid id)
        {
            var meioDeComunicacao = _context.MeiosDeComunicacao.Find(id);
            _context.MeiosDeComunicacao.Remove(meioDeComunicacao);
        }

        public MeioDeComunicacao ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeioDeComunicacao> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeioDeComunicacao> Buscar(Expression<Func<MeioDeComunicacao, bool>> predicate)
        {
            return _context.MeiosDeComunicacao.Where(predicate);
        }
    }
}
