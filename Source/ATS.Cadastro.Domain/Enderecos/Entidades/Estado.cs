using ATS.Cadastro.Domain.Pessoas.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Enderecos.Entidades
{
    public class Estado
    {
        protected Estado()
        {
        }

        public Estado(string uf, string nome)
        {
            IdEstado = Guid.NewGuid();

            UF = uf;
            Nome = nome;
            
            ListaDeCidades = new List<Cidade>();
            ListaDeEnderecos = new List<Endereco>();
            ListaDePessoasFisica = new List<PessoaFisica>();
        }

        public Estado(Guid estadoId)
        {
            IdEstado = estadoId;
        }

        #region "Propriedades"

        public Guid IdEstado { get; private set; }

        public string Nome { get; private set; }

        public string UF { get; private set; }

        public ICollection<Cidade> ListaDeCidades { get; set; }

        public ICollection<Endereco> ListaDeEnderecos { get; set; }

        public ICollection<PessoaFisica> ListaDePessoasFisica { get; set; }

        #endregion
    }
}
