using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Funcionarios.Interfaces.Services
{
    public interface ICargoService
    {
        void Adicionar(Cargo cargo);

        void Atualizar(Cargo cargo);

        void Remover(Guid id);

        Cargo ObterPorId(Guid id);

        IEnumerable<Cargo> ObterTodos();
    }
}
