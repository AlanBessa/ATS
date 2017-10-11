using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Repositories;

namespace ATS.Cadastro.Domain.MeiosDeComunicacoes.Services
{
    public class MeioDeComunicacaoService : BaseService, IMeioDeComunicacaoService
    {
        private readonly IMeioDeComunicacaoRepository _meioDeComunicacaoRepository;

        public MeioDeComunicacaoService(IMeioDeComunicacaoRepository meioDeComunicacaoRepository)
        {
            _meioDeComunicacaoRepository = meioDeComunicacaoRepository;
        }

        public MeioDeComunicacao Adicionar(MeioDeComunicacao meioDeComunicacao)
        {
            _meioDeComunicacaoRepository.Adicionar(meioDeComunicacao);

            return meioDeComunicacao;
        }

        public void Remover(Guid id)
        {
            _meioDeComunicacaoRepository.Remover(id);
        }

        public void RemoverLista(IEnumerable<MeioDeComunicacao> lista)
        {
            foreach (var item in lista)
            {
                Remover(item.IdMeioDeComunicacao);
            }
        }

        public MeioDeComunicacao ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeioDeComunicacao> ObterTodos()
        {
            throw new NotImplementedException();
        }        
    }
}
