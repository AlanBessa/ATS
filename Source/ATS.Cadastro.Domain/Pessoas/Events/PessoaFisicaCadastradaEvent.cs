using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Pessoas.Events
{
    public class PessoaFisicaCadastradaEvent : IDomainEvent
    {
        public DateTime DataOcorrencia { get; private set; }
        public PessoaFisica PessoaFisica { get; private set; }
        public string EmailTitle { get; private set; }
        public string EmailBody { get; private set; }
        public int Versao { get; private set; }

        public PessoaFisicaCadastradaEvent(PessoaFisica pessoaFisica, DateTime dateOccured)
        {
            this.Versao = 1;
            this.PessoaFisica = pessoaFisica;
            this.DataOcorrencia = DateTime.Now;
        }

        public PessoaFisicaCadastradaEvent(PessoaFisica pessoaFisica) : this(pessoaFisica, DateTime.Now) { }
    }
}
