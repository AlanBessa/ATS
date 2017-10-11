using ATS.Cadastro.Domain.Enderecos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.Enderecos.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        void Adicionar(Endereco endereco);

        void Atualizar(Endereco endereco);

        void Remover(Guid id);

        Endereco ObterPorId(Guid id);

        IEnumerable<Endereco> ObterTodos();

        IEnumerable<Endereco> Buscar(Expression<Func<Endereco, bool>> predicate);
    }
}
