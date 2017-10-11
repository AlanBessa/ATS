using System;

namespace ATS.Cadastro.Application.Commands
{
    public class CidadeCommands
    {
        public Guid? IdCidade { get; set; }

        public Guid? EstadoId { get; set; }

        public EstadoCommands Estado { get; set; }

        public string Nome { get; set; }
    }
}
