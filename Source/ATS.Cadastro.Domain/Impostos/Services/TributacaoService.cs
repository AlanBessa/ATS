using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Impostos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Cadastro.Domain.Impostos.Interfaces.Repositories;

namespace ATS.Cadastro.Domain.Impostos.Services
{
    public class TributacaoService : BaseService, ITributacaoService
    {
        private readonly ITributacaoRepository _tributacaoRepository;

        public TributacaoService(ITributacaoRepository tributacaoRepository)
        {
            _tributacaoRepository = tributacaoRepository;
        }

        public void Adicionar(Tributacao tributacao)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Tributacao tributacao)
        {
            throw new NotImplementedException();
        }

        public Tributacao ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tributacao> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
