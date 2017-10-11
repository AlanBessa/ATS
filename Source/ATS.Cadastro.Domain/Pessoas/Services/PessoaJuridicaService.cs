using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Services;
using ATS.Cadastro.Domain.Pessoas.Validations;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Pessoas.Services
{
    public class PessoaJuridicaService : BaseService, IPessoaJuridicaService
    {
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;

        public PessoaJuridicaService(IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
        }

        public PessoaJuridica Adicionar(PessoaJuridica pessoaJuridica)
        {
            if (!PossuiConformidade(new PessoaJuridicaAptaParaCadastroValidation(_pessoaJuridicaRepository).Validate(pessoaJuridica)))
                _pessoaJuridicaRepository.Adicionar(pessoaJuridica);

            return pessoaJuridica;
        }

        public PessoaJuridica Atualizar(PessoaJuridica pessoaJuridica)
        {
            if (!PossuiConformidade(new PessoaJuridicaAptaParaCadastroValidation(_pessoaJuridicaRepository).Validate(pessoaJuridica)))
                _pessoaJuridicaRepository.Atualizar(pessoaJuridica);

            return pessoaJuridica;
        }

        public PessoaJuridica ObterPorId(Guid? id)
        {
            return _pessoaJuridicaRepository.Buscar(m => m.IdPessoa == id.Value).SingleOrDefault();
        }

        public PessoaJuridica ObterPorId(Guid id)
        {
            return _pessoaJuridicaRepository.ObterPorId(id);
        }

        public IEnumerable<PessoaJuridica> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaJuridica> ObterTodosPorFiltro(string cnpj, string razaoSocial)
        {
            return _pessoaJuridicaRepository.ObterTodosPorFiltro(cnpj, razaoSocial);
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }        
    }
}
