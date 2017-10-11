using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using DomainValidation.Interfaces.Specification;

namespace ATS.Cadastro.Domain.Pessoas.Specifications
{
    public class PessoaFisicaDevePossuirRGUnicoSpecification : ISpecification<PessoaFisica>
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaDevePossuirRGUnicoSpecification(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        public bool IsSatisfiedBy(PessoaFisica pessoaFisica)
        {
            var pf = _pessoaFisicaRepository.ObterPorRG(pessoaFisica.RG);

            return (pf == null || (pf != null && pf.IdPessoa == pessoaFisica.IdPessoa));
        }
    }
}
