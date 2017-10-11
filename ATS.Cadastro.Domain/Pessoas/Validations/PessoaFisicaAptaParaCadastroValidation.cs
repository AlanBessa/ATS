using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using ATS.Cadastro.Domain.Pessoas.Specifications;
using ATS.Core.Domain.Resources;
using DomainValidation.Validation;

namespace ATS.Cadastro.Domain.Pessoas.Validations
{
    public class PessoaFisicaAptaParaCadastroValidation : Validator<PessoaFisica>
    {
        public PessoaFisicaAptaParaCadastroValidation(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            var cpfDuplicado = new PessoaFisicaDevePossuirCPFUnicoSpecification(pessoaFisicaRepository);
            var rgDuplicado = new PessoaFisicaDevePossuirRGUnicoSpecification(pessoaFisicaRepository);

            base.Add("cpfDuplicado", new Rule<PessoaFisica>(cpfDuplicado, ErrorMessage.CPFJaExiste));
            base.Add("rgDuplicado", new Rule<PessoaFisica>(rgDuplicado, ErrorMessage.RGJaExiste));
        }        
    }
}
