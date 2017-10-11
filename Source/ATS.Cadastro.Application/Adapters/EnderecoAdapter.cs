using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Application.Adapters
{
    public class EnderecoAdapter
    {
        public static Endereco ToDomainModel(EnderecoCommands enderecoVM)
        {
            if (enderecoVM == null) return null;

            var endereco = new Endereco(
                enderecoVM.Logradouro,
                enderecoVM.Complemento,
                enderecoVM.Numero,
                enderecoVM.Bairro,
                enderecoVM.CidadeId.Value,
                enderecoVM.EstadoId.Value,
                enderecoVM.Cep);

            return endereco;
        }

        public static EnderecoCommands ToModelDomain(Endereco endereco)
        {
            if (endereco == null) return null;

            var enderecoVM = new EnderecoCommands();
            enderecoVM.IdEndereco = endereco.IdEndereco;
            enderecoVM.Logradouro = endereco.Logradouro;
            enderecoVM.Numero = endereco.Numero;
            enderecoVM.Bairro = endereco.Bairro;
            enderecoVM.Complemento = endereco.Complemento;
            enderecoVM.Cep = endereco.Cep.CepCod;
            enderecoVM.Cidade = CidadeAdapter.ToModelDomain(endereco.Cidade);
            enderecoVM.Estado = EstadoAdapter.ToModelDomain(endereco.Estado);

            return enderecoVM;
        }
    }
}
