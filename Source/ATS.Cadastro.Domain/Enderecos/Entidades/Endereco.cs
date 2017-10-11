using ATS.Cadastro.Domain.Agendas.Entidades;
using ATS.Cadastro.Domain.Contatos;
using ATS.Cadastro.Domain.Enderecos.Scopes;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.Helpers;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Enderecos.Entidades
{
    public class Endereco
    {   
        protected Endereco()
        {
        }

        public Endereco(string logradouro, string complemento, string numero, string bairro,
            Guid cidadeId, Guid estadoId, string cep)
        {
            IdEndereco = Guid.NewGuid();
            DefinirCep(cep);
            DefinirBairro(bairro);
            DefinirCidade(cidadeId);
            DefinirEstado(estadoId);
            DefinirComplemento(complemento);
            DefinirLogradouro(logradouro);
            DefinirNumero(numero);

            ListaDePessoas = new List<Pessoa>();
            ListaDeContatos = new List<Contato>();
            ListaDeAgendas = new List<Agenda>();
        }

        #region "Propriedades"
        
        public Guid IdEndereco { get; private set; }

        public string Logradouro { get; private set; }

        public string Complemento { get; private set; }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public Guid CidadeId { get; private set; }

        public Cidade Cidade { get; private set; }

        public Guid EstadoId { get; private set; }

        public Estado Estado { get; private set; }

        public CEP Cep { get; private set; }

        public ICollection<Pessoa> ListaDePessoas { get; set; }

        public ICollection<Contato> ListaDeContatos { get; set; }

        public ICollection<Agenda> ListaDeAgendas { get; set; }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Metodos"

        public void DefinirCep(string cep)
        {
            var tempCep = TextoHelper.GetNumeros(cep);

            if (this.DefinirCEPScopeEhValido(tempCep))
                Cep = new CEP(tempCep);
        }

        public void DefinirComplemento(string complemento)
        {
            if (string.IsNullOrEmpty(complemento))
                complemento = "";
            Complemento = TextoHelper.ToTitleCase(complemento);
        }

        public void DefinirLogradouro(string logradouro)
        {
            if (this.DefinirLogradouroScopeEhValido(logradouro))
                Logradouro = TextoHelper.ToTitleCase(logradouro);
        }

        public void DefinirNumero(string numero)
        {
            if (this.DefinirNumeroScopeEhValido(numero))
                Numero = numero;
        }

        public void DefinirBairro(string bairro)
        {
            if (this.DefinirBairroScopeEhValido(bairro))
                Bairro = TextoHelper.ToTitleCase(bairro);
        }

        public void DefinirCidade(Guid cidadeId)
        {
            if (this.DefinirCidadeScopeEhValido(cidadeId))
                CidadeId = cidadeId;
        }

        public void DefinirCidade(Cidade cidade)
        {
            if (this.DefinirCidadeScopeEhValido(cidade))
                Cidade = cidade;
        }

        public void DefinirEstado(Guid estadoId)
        {
            if (this.DefinirEstadoScopeEhValido(estadoId))
                EstadoId = estadoId;
        }

        public void DefinirEstado(Estado estado)
        {
            if (this.DefinirEstadoScopeEhValido(estado))
                Estado = estado;
        }

        public void DefinirObjetoCidade(Cidade cidade)
        {
            Cidade = cidade;
        }

        public void DefinirObjetoEstado(Estado estado)
        {
            Estado = estado;
        }

        public override string ToString()
        {
            return Logradouro + ", " + Numero + " - " + Complemento + " <br /> " + Bairro + " - " + Cidade.Nome + "/" + Estado.Nome;
        }

        #endregion  
    }
}