using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using ATS.Cadastro.Domain.Pessoas.Specifications;
using ATS.Core.Domain.Resources;
using DomainValidation.Validation;

namespace ATS.Cadastro.Domain.Pessoas.Validations
{
    public class PessoaJuridicaAptaParaCadastroValidation : Validator<PessoaJuridica>
    {
        public PessoaJuridicaAptaParaCadastroValidation(IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            var cnpjDuplicado = new PessoaJuridicaDevePossuirCNPJUnicoSpecification(pessoaJuridicaRepository);

            base.Add("cnpjDuplicado", new Rule<PessoaJuridica>(cnpjDuplicado, ErrorMessage.CNPJJaExiste));
        }
    }
}
