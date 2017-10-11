using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Produtos.Interfaces.Repositories;
using ATS.Cadastro.Domain.Produtos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Produtos.Entidades;

namespace ATS.Cadastro.Domain.Produtos.Services
{
    public class MarcaService : BaseService, IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public void Adicionar(Marca marca)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Marca marca)
        {
            throw new NotImplementedException();
        }

        public Marca ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Marca> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
