using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Funcionarios.Interfaces.Services
{
    public interface IFuncionarioService
    {
        void Adicionar(Funcionario funcionario);

        void Atualizar(Funcionario funcionario);

        void Remover(Guid id);

        Funcionario ObterPorId(Guid id);

        IEnumerable<Funcionario> ObterTodos();
    }
}
