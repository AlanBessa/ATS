using ATS.Core.Domain.Interfaces;
using System;

namespace ATS.Cadastro.Domain.Contatos.Interfaces.Eventos
{
    public class ContatoCadastroEvent : IDomainEvent
    {
        public ContatoCadastroEvent(Contato contato) : this(contato, DateTime.Now) { }

        public ContatoCadastroEvent(Contato contato, DateTime dataOcorrencia)
        {
            Versao = 1;
            Contato = contato;
            DataOcorrencia = dataOcorrencia;
        }

        public Contato Contato { get; set; }

        public DateTime DataOcorrencia { get; private set; }

        public int Versao { get; private set; }
    }
}
