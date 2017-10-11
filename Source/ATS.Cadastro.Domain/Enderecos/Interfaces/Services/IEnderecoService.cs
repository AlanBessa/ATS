using ATS.Cadastro.Domain.Enderecos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Enderecos.Interfaces.Services
{
    public interface IEnderecoService
    {
        Endereco Adicionar(Endereco endereco);

        void Remover(Guid id);

        Endereco ObterPorId(Guid id);

        void RemoverLista(IEnumerable<Endereco> lista);
    }
}
