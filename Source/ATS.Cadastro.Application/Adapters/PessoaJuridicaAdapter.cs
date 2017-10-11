using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.Helpers;
using System;

namespace ATS.Cadastro.Application.Adapters
{
    public class PessoaJuridicaAdapter
    {
        public static PessoaJuridica ToDomainModel(PessoaJuridicaCommands pessoaVM)
        {
            if (pessoaVM == null) return null;

            var pessoa = new PessoaJuridica(
                pessoaVM.RazaoSocial,
                pessoaVM.NomeFantasia,
                pessoaVM.CNPJ,
                pessoaVM.Inscricao,
                pessoaVM.Status,
                pessoaVM.IdPessoa);
            
            pessoa.LimiteDeCredito = string.IsNullOrEmpty(pessoaVM.LimiteDeCredito) ? 0M : Convert.ToDecimal(TextoHelper.LimparMascaraValorMonetario(pessoaVM.LimiteDeCredito));
            pessoa.SPC = pessoaVM.SPC;
            pessoa.Observacao = pessoaVM.Observacao;
            pessoa.DataDaUltimaCompra = pessoaVM.DataDaUltimaCompra;
            pessoa.Referencias = pessoaVM.Referencias;

            return pessoa;
        }

        public static PessoaJuridicaCommands ToModelDomain(PessoaJuridica pessoa)
        {
            if (pessoa == null) return null;

            var pessoaVM = new PessoaJuridicaCommands();
            pessoaVM.Conceito = pessoa.Conceito;
            pessoaVM.CNPJ = pessoa.CNPJ.Codigo;
            pessoaVM.DataDaUltimaCompra = pessoa.DataDaUltimaCompra;
            pessoaVM.RazaoSocial = pessoa.RazaoSocial;
            pessoaVM.NomeFantasia = pessoa.NomeFantasia;
            pessoaVM.IdPessoa = pessoa.IdPessoa;
            pessoaVM.LimiteDeCredito = pessoa.LimiteDeCredito.ToString();
            pessoaVM.Inscricao = pessoa.Inscricao;
            pessoaVM.Socio = PessoaFisicaAdapter.ToModelDomain(pessoa.Socio);
            pessoaVM.SocioId = pessoa.SocioId;
            pessoaVM.SocioMenor = PessoaFisicaAdapter.ToModelNoValidationDomain(pessoa.SocioMenor);
            pessoaVM.SocioMenorId = pessoa.SocioMenorId;
            pessoaVM.Observacao = pessoa.Observacao;
            pessoaVM.Referencias = pessoa.Referencias;
            pessoaVM.SPC = pessoa.SPC;
            pessoaVM.Status = pessoa.Status;

            return pessoaVM;
        }
    }
}
