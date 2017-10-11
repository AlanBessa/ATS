using ATS.Core.Domain.ValueObjects;
using System;

namespace ATS.Cadastro.Domain.Enderecos.Entidades
{
    public class EnderecoId : Aggregate
    {
        public EnderecoId()
        {

        }

        public EnderecoId(Guid id)
            : base(id)
        {

        }
    }
}
