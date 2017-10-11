using System;

namespace ATS.Cadastro.Application.Commands
{
    public class MeioDeComunicacaoCommands
    {
        public Guid IdMeioDeComunicacao { get; set; }

        public string Valor { get; set; }

        public Guid TipoDeMeioDeComunicacaoId { get; set; }

        public TipoDeMeioDeComunicacaoCommands TipoDeMeioDeComunicacao { get; set; }

        public Guid PessoaId { get; set; }

        public PessoaFisicaCommands Pessoa { get; set; }
    }
}
