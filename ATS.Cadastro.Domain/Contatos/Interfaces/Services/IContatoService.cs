using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Contatos.Interfaces.Services
{
    public interface IContatoService
    {
        void Adicionar(Contato contato);

        void Atualizar(Contato contato);

        void Remover(Guid id);

        Contato ObterPorId(Guid id);

        IEnumerable<Contato> ObterTodos();
    }
}
