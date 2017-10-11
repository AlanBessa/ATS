using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Produtos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Produtos.Entidades;
using ATS.Cadastro.Domain.Produtos.Interfaces.Repositories;

namespace ATS.Cadastro.Domain.Produtos.Services
{
    public class CorService : BaseService, ICorService
    {
        private readonly ICorRepository _corRepository;

        public CorService(ICorRepository corRepository)
        {
            _corRepository = corRepository;
        }

        public void Adicionar(Cor cor)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Cor cor)
        {
            throw new NotImplementedException();
        }

        public Cor ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cor> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
