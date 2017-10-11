using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Application.Adapters
{
    public class EstadoAdapter
    {
        public static Estado ToDomainModel(EstadoCommands estadoVM)
        {
            if (estadoVM == null) return null;

            var estado = new Estado(
                estadoVM.Nome,
                estadoVM.UF);

            return estado;
        }

        public static EstadoCommands ToModelDomain(Estado estado)
        {
            if (estado == null) return null;

            var estadoVM = new EstadoCommands();

            estadoVM.IdEstado = estado.IdEstado;
            estadoVM.Nome = estado.Nome;
            estadoVM.UF = estado.UF;

            return estadoVM;
        }
    }
}
