using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Services
{
    public interface IIpiService
    {
        void Adicionar(Ipi ipi);

        void Atualizar(Ipi ipi);

        void Remover(Guid id);

        Ipi ObterPorId(Guid id);

        IEnumerable<Ipi> ObterTodos();
    }
}
