using ATS.Cadastro.Domain.Contatos;
using ATS.Cadastro.Domain.Pessoas.Scopes;
using ATS.Core.Domain.Helpers;
using ATS.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Pessoas.Entidades
{
    public class PessoaJuridica : Pessoa
    {
        #region "Constantes"

        public const int TamanhoMinLength = 6;
        public const int TamanhoMaxLength = 200;

        #endregion

        protected PessoaJuridica()
        {
        }

        public PessoaJuridica(string razaoSocial, string nomeFantasia, string cnpj, string inscricao, string status, Guid? idPessoa)
            : base(status, idPessoa)
        {
            DefinirRazaoSocial(razaoSocial);
            DefinirNomeFantasia(nomeFantasia);
            DefinirCNPJ(cnpj);
            DefinirInscricao(inscricao);
            DataDeCriacao = DateTime.Now;

            ListaDeContatos = new List<Contato>();
        }

        #region "Propriedades"

        public string RazaoSocial { get; private set; }

        public string NomeFantasia { get; private set; }

        public CNPJ CNPJ { get; private set; }

        public string Inscricao { get; private set; }

        public DateTime DataDeCriacao { get; private set; }

        public Guid? SocioId { get; private set; }

        public PessoaFisica Socio { get; private set; }

        public Guid? SocioMenorId { get; private set; }

        public PessoaFisica SocioMenor { get; private set; }

        public ICollection<Contato> ListaDeContatos { get; set; }

        #endregion

        #region "Métodos"

        public void DefinirRazaoSocial(string razaoSocial)
        {
            if (!this.DefinirRazaoSocialPessoaJuridicaScopeEhValido(razaoSocial))
                return;

            RazaoSocial = razaoSocial;
        }

        public void DefinirNomeFantasia(string nomeFantasia)
        {
            if (!this.DefinirNomeFantasiaPessoaJuridicaScopeEhValido(nomeFantasia))
                return;

            NomeFantasia = nomeFantasia;
        }

        public void DefinirCNPJ(string cnpj)
        {
            var tempCNPJ = new CNPJ(TextoHelper.GetNumeros(cnpj));

            //Verificar se vai ser necessario limpar o cnpj dos caractes especiais

            if (!this.DefinirCNPJPessoaJuridicaScopeEhValido(tempCNPJ))
                return;

            CNPJ = tempCNPJ;
        }

        public void DefinirInscricao(string inscricao)
        {
            if (!this.DefinirInscricaoPessoaJuridicaScopeEhValido(inscricao))
                return;

            Inscricao = inscricao;
        }

        public void DefinirSocioPrincipal(Guid? idSocioPrincipal)
        {
            if (!this.DefinirNomeDoSocioPessoaJuridicaScopeEhValido(idSocioPrincipal))
                return;

            SocioId = idSocioPrincipal;
        }

        public void DefinirSocioPrincipal(PessoaFisica socioPrincipal)
        {
            if (!this.DefinirNomeDoSocioPessoaJuridicaScopeEhValido(socioPrincipal))
                return;

            Socio = socioPrincipal;
        }

        public void DefinirSocioSecundario(Guid? idSocioSecundario)
        {
            if (!this.DefinirNomeDoSocioPessoaJuridicaScopeEhValido(idSocioSecundario))
                return;

            SocioMenorId = idSocioSecundario;
        }

        public void DefinirSocioSecundario(PessoaFisica socioSecundario)
        {
            if (!this.DefinirNomeDoSocioPessoaJuridicaScopeEhValido(socioSecundario))
                return;

            SocioMenor = socioSecundario;
        }

        #endregion
    }
}
