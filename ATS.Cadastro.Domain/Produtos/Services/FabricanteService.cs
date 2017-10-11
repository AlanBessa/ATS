using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Produtos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Domain.Produtos.Entidades;
using ATS.Cadastro.Domain.Produtos.Interfaces.Repositories;

namespace ATS.Cadastro.Domain.Produtos.Services
{
    public class FabricanteService : BaseService, IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public FabricanteService(IFabricanteRepository fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }

        public void Adicionar(Fabricante fabricante)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Fabricante fabricante)
        {
            throw new NotImplementedException();
        }

        public Fabricante ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fabricante> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
