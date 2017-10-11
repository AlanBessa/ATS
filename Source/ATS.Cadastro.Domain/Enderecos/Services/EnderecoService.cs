using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Services;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Enderecos.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public Endereco Adicionar(Endereco endereco)
        {
            //if (!PossuiConformidade(new PessoaFisicaAptaParaCadastroValidation(_pessoaFisicaRepository).Validate(pessoaFisica)))
            _enderecoRepository.Adicionar(endereco);

            return endereco;
        }

        public Endereco ObterPorId(Guid id)
        {
            return _enderecoRepository.ObterPorId(id);
        }

        public void Remover(Guid id)
        {
            _enderecoRepository.Remover(id);
        }

        public void RemoverLista(IEnumerable<Endereco> lista)
        {
            foreach (var item in lista)
            {
                Remover(item.IdEndereco);
            }
        }
    }
}
