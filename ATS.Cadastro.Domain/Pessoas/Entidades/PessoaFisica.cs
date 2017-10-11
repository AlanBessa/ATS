using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Domain.Pessoas.Scopes;
using ATS.Core.Domain.Helpers;
using ATS.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Pessoas.Entidades
{
    public class PessoaFisica : Pessoa
    {
        #region "Constantes"

        public const int NomeMinLength = 6;
        public const int NomeMaxLength = 200;

        #endregion

        protected PessoaFisica()
        {
        }

        public PessoaFisica(string nome, string cpf, string rg, string tituloEleitor, DateTime? dataDeNascimento, 
                            Guid? idNaturalidade, string nacionalidade, ESexo sexo, 
                            EEstadoCivil estadoCivil, string status, Guid? idPessoa)
            : base (status, idPessoa)
        {
            DefinirNome(nome);
            DefinirCPF(cpf);
            RG = rg;
            DefinirDataDeNascimento(dataDeNascimento);
            DefinirNaturalidade(idNaturalidade);
            Nacionalidade = nacionalidade;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            TituloEleitor = tituloEleitor;
            NomeDoPai = string.Empty;
            NomeDaMae = string.Empty;
            Salario = 0M;

            ListaDeSocios = new List<PessoaJuridica>();
            ListaDeSociosMenores = new List<PessoaJuridica>();
        }

        #region "Propriedades"

        public string Nome { get; private set; }

        public CPF CPF { get; private set; }

        public string RG { get; private set; }

        public string TituloEleitor { get; private set; }

        public DateTime DataDeNascimento { get; private set; }

        public string NomeDoPai { get; set; }

        public string NomeDaMae { get; set; }

        public Guid? NaturalidadeId { get; private set; }

        public Estado Naturalidade { get; private set; }

        public string Nacionalidade { get; private set; }

        public ESexo Sexo { get; private set; }

        public EEstadoCivil EstadoCivil { get; private set; }

        public decimal Salario { get; set; }

        public ICollection<PessoaJuridica> ListaDeSocios { get; set; }

        public ICollection<PessoaJuridica> ListaDeSociosMenores { get; set; }

        #endregion

        #region "Metodos"

        private void DefinirNome(string nome)
        {
            if (!this.DefinirNomeScopeEhValido(nome))
                return;

            Nome = nome;
        }

        public void DefinirCPF(string cpf)
        {
            var tempCpf = new CPF(TextoHelper.GetNumeros(cpf));

            if (!this.DefinirCPFPessoaFisicaScopeEhValido(tempCpf))
                return;

            CPF = tempCpf;
        }

        private void DefinirDataDeNascimento(DateTime? data)
        {
            if (!this.DefinirDataDeNascimentoPessoaFisicaScopeEhValido(data))
                return;

            DataDeNascimento = data.Value;
        }

        private void DefinirNaturalidade(Guid? idNaturalidade)
        {
            if (this.DefinirNaturalidadePessoaFisicaScopeEhValido(idNaturalidade))
                NaturalidadeId = idNaturalidade.Value;
        }

        #endregion
    }
}
