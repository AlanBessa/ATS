using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Services;
using System.Collections.Generic;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Repositories;
using System;

namespace ATS.Cadastro.Domain.MeiosDeComunicacoes.Services
{
    public class TipoDeMeioDeComunicacaoService : BaseService, ITipoDeMeioDeComunicacaoService
    {
        private readonly ITipoDeMeioDeComunicacaoRepository _tipoDeMeioDeComunicacaoRepository;

        public TipoDeMeioDeComunicacaoService(ITipoDeMeioDeComunicacaoRepository tipoDeMeioDeComunicacaoRepository)
        {
            _tipoDeMeioDeComunicacaoRepository = tipoDeMeioDeComunicacaoRepository;
        }

        public TipoDeMeioDeComunicacao ObterPorId(Guid idTipo)
        {
            return _tipoDeMeioDeComunicacaoRepository.ObterPorId(idTipo);
        }

        public TipoDeMeioDeComunicacao ObterTipoDeMeioPor(string descricao)
        {
            return _tipoDeMeioDeComunicacaoRepository.ObterTipoDeMeioPor(descricao);
        }

        public IEnumerable<TipoDeMeioDeComunicacao> ObterTodosOsTipos()
        {
            return _tipoDeMeioDeComunicacaoRepository.ObterTodosOsTipos();
        }
    }
}
