using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Produtos.Interfaces.Services
{
    public interface IFabricanteService
    {
        void Adicionar(Fabricante fabricante);

        void Atualizar(Fabricante fabricante);

        void Remover(Guid id);

        Fabricante ObterPorId(Guid id);

        IEnumerable<Fabricante> ObterTodos();
    }
}
