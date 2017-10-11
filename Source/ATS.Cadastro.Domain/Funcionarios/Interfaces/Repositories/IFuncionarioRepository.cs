using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Funcionarios.Interfaces.Repositories
{
    public interface IFuncionarioRepository
    {
        void Adicionar(Funcionario funcionario);

        void Atualizar(Funcionario funcionario);

        void Remover(Guid id);

        Funcionario ObterPorId(Guid id);

        IEnumerable<Funcionario> ObterTodos();

        IEnumerable<Funcionario> Buscar(Expression<Func<Funcionario, bool>> predicate);
    }
}
