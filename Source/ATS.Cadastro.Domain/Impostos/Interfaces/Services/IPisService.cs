using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Services
{
    public interface IPisService
    {
        void Adicionar(Pis pis);

        void Atualizar(Pis pis);

        void Remover(Guid id);

        Pis ObterPorId(Guid id);

        IEnumerable<Pis> ObterTodos();
    }
}
