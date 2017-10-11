using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Enderecos.Entidades
{
    public class Cidade
    {
        protected Cidade()
        {
        }   

        public Cidade(Guid cidadeId)
        {
            IdCidade = cidadeId;
        }

        public Cidade(string nome, Guid estadoId, Guid? idCidade)
        {
            IdCidade = idCidade == null ? Guid.NewGuid() : idCidade.Value;

            Nome = nome;            
            EstadoId = estadoId;

            ListaDeEnderecos = new List<Endereco>();
        }

        #region "Propriedades"

        public Guid IdCidade { get; private set; }

        public Guid EstadoId { get; private set; }

        public Estado Estado { get; private set; }

        public string Nome { get; private set; }

        public ICollection<Endereco> ListaDeEnderecos { get; set; }

        #endregion
    }
}
