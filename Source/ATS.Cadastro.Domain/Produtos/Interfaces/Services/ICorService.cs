using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Produtos.Interfaces.Services
{
    public interface ICorService
    {
        void Adicionar(Cor cor);

        void Atualizar(Cor cor);

        void Remover(Guid id);

        Cor ObterPorId(Guid id);

        IEnumerable<Cor> ObterTodos();
    }
}
