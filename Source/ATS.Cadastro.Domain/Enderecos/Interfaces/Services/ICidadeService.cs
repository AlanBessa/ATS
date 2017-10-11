using ATS.Cadastro.Domain.Enderecos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Enderecos.Interfaces.Services
{
    public interface ICidadeService
    {
        IEnumerable<Cidade> ObterTodasCidadesPor(Guid idEstado);
    }
}
