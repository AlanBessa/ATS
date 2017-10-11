using ATS.Cadastro.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Application.Interfaces
{
    public interface ICidadeApp
    {
        IEnumerable<CidadeCommands> ObterTodasCidadesPor(Guid idEstado);
    }
}
