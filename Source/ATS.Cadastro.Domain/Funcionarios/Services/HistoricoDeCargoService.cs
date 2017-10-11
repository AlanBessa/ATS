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
    public class HistoricoDeCargoService : BaseService, IHistoricoDeCargoService
    {
        private readonly IHistoricoDeCargoRepository _historicoDeCargoRepository;

        public HistoricoDeCargoService(IHistoricoDeCargoRepository historicoDeCargRepository)
        {
            _historicoDeCargoRepository = historicoDeCargRepository;
        }

        public void Adicionar(HistoricoDeCargo historicoDeCargo)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(HistoricoDeCargo historicoDeCargo)
        {
            throw new NotImplementedException();
        }

        public HistoricoDeCargo ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistoricoDeCargo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
