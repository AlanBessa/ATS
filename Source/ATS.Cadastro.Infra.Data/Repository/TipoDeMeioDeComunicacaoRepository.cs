using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Repositories;
using System.Linq;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using ATS.Cadastro.Infra.Data.Context;
using System.Collections.Generic;
using System;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class TipoDeMeioDeComunicacaoRepository : BaseRepository, ITipoDeMeioDeComunicacaoRepository
    {
        private readonly CadastroContext _context;

        public TipoDeMeioDeComunicacaoRepository(CadastroContext context)
        {
            _context = context;
        }

        public TipoDeMeioDeComunicacao ObterPorId(Guid idTipo)
        {
            return _context.TiposDeMeioDeComunicacao.Find(idTipo);
        }

        public TipoDeMeioDeComunicacao ObterTipoDeMeioPor(string descricao)
        {
            return _context.TiposDeMeioDeComunicacao.Where(m => m.Descricao.Equals(descricao)).FirstOrDefault();
        }

        public IEnumerable<TipoDeMeioDeComunicacao> ObterTodosOsTipos()
        {
            return _context.TiposDeMeioDeComunicacao.ToList();
        }
    }
}
