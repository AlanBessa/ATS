using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Funcionarios.Interfaces.Repositories
{
    public interface ICargoRepository
    {
        void Adicionar(Cargo cargo);

        void Atualizar(Cargo cargo);

        void Remover(Guid id);

        Cargo ObterPorId(Guid id);

        IEnumerable<Cargo> ObterTodos();

        IEnumerable<Cargo> Buscar(Expression<Func<Cargo, bool>> predicate);
    }
}
