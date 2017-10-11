using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using DomainValidation.Interfaces.Specification;

namespace ATS.Cadastro.Domain.Pessoas.Specifications
{
    public class PessoaJuridicaDevePossuirCNPJUnicoSpecification : ISpecification<PessoaJuridica>
    {
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;

        public PessoaJuridicaDevePossuirCNPJUnicoSpecification(IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
        }

        public bool IsSatisfiedBy(PessoaJuridica pessoaJuridica)
        {
            if (pessoaJuridica.CNPJ == null) return false;

            var pj = _pessoaJuridicaRepository.ObterPorCNPJ(pessoaJuridica.CNPJ.Codigo);

            return (pj == null || (pj != null && pj.IdPessoa == pessoaJuridica.IdPessoa));
        }
    }
}
