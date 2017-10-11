using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Services
{
    public interface ICofinsService
    {
        void Adicionar(Cofins cofins);

        void Atualizar(Cofins cofins);

        void Remover(Guid id);

        Cofins ObterPorId(Guid id);

        IEnumerable<Cofins> ObterTodos();
    }
}
