using ATS.Cadastro.Domain.Pessoas.Interfaces.Services;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Pessoas.Validations;
using System;
using System.Linq;
using System.Collections.Generic;
using ATS.Core.Domain.ValueObjects;

namespace ATS.Cadastro.Domain.Pessoas.Services
{
    public class PessoaFisicaService : BaseService, IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaService(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        public PessoaFisica Adicionar(PessoaFisica pessoaFisica)
        {
            if (!PossuiConformidade(new PessoaFisicaAptaParaCadastroValidation(_pessoaFisicaRepository).Validate(pessoaFisica)))
                _pessoaFisicaRepository.Adicionar(pessoaFisica);

            return pessoaFisica;
        }

        public PessoaFisica Atualizar(PessoaFisica pessoaFisica)
        {
            if (!PossuiConformidade(new PessoaFisicaAptaParaEdicaoValidation(_pessoaFisicaRepository).Validate(pessoaFisica)))
                _pessoaFisicaRepository.Atualizar(pessoaFisica);

            return pessoaFisica;
        }

        public PessoaFisica ObterPorId(Guid id)
        {
            return _pessoaFisicaRepository.ObterPorId(id);
        }

        public IEnumerable<PessoaFisica> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaFisica> ObterTodosPorFiltro(string cpf, string nome)
        {
            return _pessoaFisicaRepository.ObterTodosPorFiltro(cpf, nome);
        }

        public void Remover(Guid id)
        {
            _pessoaFisicaRepository.Remover(id);
        }

        public IEnumerable<EEstadoCivil> ObterTodosOsEstadosCivis()
        {
            return Enum.GetValues(typeof(EEstadoCivil)).Cast<EEstadoCivil>();
        }
    }
}
