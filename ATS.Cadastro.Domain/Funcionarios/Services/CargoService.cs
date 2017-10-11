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
    public class CargoService : BaseService, ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public void Adicionar(Cargo cargo)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Cargo cargo)
        {
            throw new NotImplementedException();
        }

        public Cargo ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cargo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
