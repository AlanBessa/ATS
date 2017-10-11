using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Produtos.Interfaces.Services
{
    public interface IMarcaService
    {
        void Adicionar(Marca marca);

        void Atualizar(Marca marca);

        void Remover(Guid id);

        Marca ObterPorId(Guid id);

        IEnumerable<Marca> ObterTodos();
    }
}
