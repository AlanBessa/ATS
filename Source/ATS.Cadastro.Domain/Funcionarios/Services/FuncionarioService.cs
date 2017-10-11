using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Funcionarios.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Cadastro.Domain.Funcionarios.Entidades;
using ATS.Cadastro.Domain.Funcionarios.Interfaces.Repositories;

namespace ATS.Cadastro.Domain.Funcionarios.Services
{
    public class FuncionarioService : BaseService, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public void Adicionar(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Funcionario ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Funcionario> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
