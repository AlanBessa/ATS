using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using DomainValidation.Interfaces.Specification;

namespace ATS.Cadastro.Domain.Pessoas.Specifications
{
    public class PessoaFisicaDevePossuirCPFUnicoSpecification : ISpecification<PessoaFisica>
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaDevePossuirCPFUnicoSpecification(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        public bool IsSatisfiedBy(PessoaFisica pessoaFisica)
        {
            var pf = _pessoaFisicaRepository.ObterPorCPF(pessoaFisica.CPF.Codigo);

            return (pf == null || (pf != null && pf.IdPessoa == pessoaFisica.IdPessoa));
        }
    }
}
