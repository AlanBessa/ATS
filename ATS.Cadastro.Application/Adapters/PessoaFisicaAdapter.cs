using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.Helpers;
using ATS.Core.Domain.ValueObjects;
using System;

namespace ATS.Cadastro.Application.Adapters
{
    public class PessoaFisicaAdapter
    {
        public static PessoaFisica ToDomainModel(PessoaFisicaCommands pessoaVM)
        {
            if (pessoaVM == null) return null;

            var pessoa = new PessoaFisica(
                pessoaVM.Nome,
                pessoaVM.CPF,
                pessoaVM.RG,
                pessoaVM.TituloDeEleitor,
                pessoaVM.DataDeNascimento,
                pessoaVM.NaturalidadeId,
                pessoaVM.Nacionalidade,
                (ESexo)pessoaVM.Sexo,
                pessoaVM.EstadoCivil,
                pessoaVM.Status,
                pessoaVM.IdPessoa);

            pessoa.NomeDoPai = pessoaVM.NomeDoPai;
            pessoa.NomeDaMae = pessoaVM.NomeDaMae;
            pessoa.Salario = string.IsNullOrEmpty(pessoaVM.Salario) ? 0M : Convert.ToDecimal(TextoHelper.LimparMascaraValorMonetario(pessoaVM.Salario));
            pessoa.LimiteDeCredito = string.IsNullOrEmpty(pessoaVM.LimiteDeCredito) ? 0M : Convert.ToDecimal(TextoHelper.LimparMascaraValorMonetario(pessoaVM.LimiteDeCredito));
            pessoa.SPC = pessoaVM.SPC;
            pessoa.Observacao = pessoaVM.Observacao;
            pessoa.DataDaUltimaCompra = pessoaVM.DataDaUltimaCompra;
            pessoa.Referencias = pessoaVM.Referencias;

            return pessoa;
        }

        public static PessoaFisicaCommands ToModelDomain(PessoaFisica pessoa)
        {
            if (pessoa == null) return null;

            var pessoaVM = new PessoaFisicaCommands();
            pessoaVM.Conceito = pessoa.Conceito;
            pessoaVM.CPF = pessoa.CPF == null ? string.Empty : pessoa.CPF.Codigo;
            pessoaVM.DataDaUltimaCompra = pessoa.DataDaUltimaCompra;
            pessoaVM.DataDeNascimento = pessoa.DataDeNascimento;
            pessoaVM.EstadoCivil = pessoaVM.EstadoCivil;
            pessoaVM.IdPessoa = pessoa.IdPessoa;
            pessoaVM.LimiteDeCredito = pessoa.LimiteDeCredito.ToString();
            pessoaVM.Nacionalidade = pessoa.Nacionalidade;
            pessoaVM.Naturalidade = EstadoAdapter.ToModelDomain(pessoa.Naturalidade);
            pessoaVM.NaturalidadeId = pessoa.NaturalidadeId;
            pessoaVM.Nome = pessoa.Nome;
            pessoaVM.NomeDaMae = pessoa.NomeDaMae;
            pessoaVM.NomeDoPai = pessoa.NomeDoPai;
            pessoaVM.Observacao = pessoa.Observacao;
            pessoaVM.Referencias = pessoa.Referencias;
            pessoaVM.RG = pessoa.RG;
            pessoaVM.Salario = pessoa.Salario.ToString();
            pessoaVM.Sexo = (int)pessoa.Sexo;
            pessoaVM.SPC = pessoa.SPC;
            pessoaVM.Status = pessoa.Status;
            pessoaVM.TituloDeEleitor = pessoa.TituloEleitor;

            return pessoaVM;
        }

        public static PessoaFisica ToDomainModelNoValidation(PessoaFisicaNoValidationCommands pessoaVM)
        {
            if (pessoaVM == null) return null;

            var pessoa = new PessoaFisica(
                pessoaVM.Nome,
                pessoaVM.CPF,
                pessoaVM.RG,
                pessoaVM.TituloDeEleitor,
                pessoaVM.DataDeNascimento,
                pessoaVM.NaturalidadeId,
                pessoaVM.Nacionalidade,
                (ESexo)pessoaVM.Sexo,
                pessoaVM.EstadoCivil,
                pessoaVM.Status,
                pessoaVM.IdPessoa);

            pessoa.NomeDoPai = pessoaVM.NomeDoPai;
            pessoa.NomeDaMae = pessoaVM.NomeDaMae;
            pessoa.Salario = string.IsNullOrEmpty(pessoaVM.Salario) ? 0M : Convert.ToDecimal(TextoHelper.LimparMascaraValorMonetario(pessoaVM.Salario));
            pessoa.LimiteDeCredito = string.IsNullOrEmpty(pessoaVM.LimiteDeCredito) ? 0M : Convert.ToDecimal(TextoHelper.LimparMascaraValorMonetario(pessoaVM.LimiteDeCredito));
            pessoa.SPC = pessoaVM.SPC;
            pessoa.Observacao = pessoaVM.Observacao;
            pessoa.DataDaUltimaCompra = pessoaVM.DataDaUltimaCompra;
            pessoa.Referencias = pessoaVM.Referencias;

            return pessoa;
        }

        public static PessoaFisicaNoValidationCommands ToModelNoValidationDomain(PessoaFisica pessoa)
        {
            if (pessoa == null) return null;

            var pessoaVM = new PessoaFisicaNoValidationCommands();
            pessoaVM.Conceito = pessoa.Conceito;
            pessoaVM.CPF = pessoa.CPF == null ? string.Empty : pessoa.CPF.Codigo;
            pessoaVM.DataDaUltimaCompra = pessoa.DataDaUltimaCompra;
            pessoaVM.DataDeNascimento = pessoa.DataDeNascimento;
            pessoaVM.EstadoCivil = pessoaVM.EstadoCivil;
            pessoaVM.IdPessoa = pessoa.IdPessoa;
            pessoaVM.LimiteDeCredito = pessoa.LimiteDeCredito.ToString();
            pessoaVM.Nacionalidade = pessoa.Nacionalidade;
            pessoaVM.Naturalidade = EstadoAdapter.ToModelDomain(pessoa.Naturalidade);
            pessoaVM.NaturalidadeId = pessoa.NaturalidadeId;
            pessoaVM.Nome = pessoa.Nome;
            pessoaVM.NomeDaMae = pessoa.NomeDaMae;
            pessoaVM.NomeDoPai = pessoa.NomeDoPai;
            pessoaVM.Observacao = pessoa.Observacao;
            pessoaVM.Referencias = pessoa.Referencias;
            pessoaVM.RG = pessoa.RG;
            pessoaVM.Salario = pessoa.Salario.ToString();
            pessoaVM.Sexo = (int)pessoa.Sexo;
            pessoaVM.SPC = pessoa.SPC;
            pessoaVM.Status = pessoa.Status;
            pessoaVM.TituloDeEleitor = pessoa.TituloEleitor;

            return pessoaVM;
        }
    }
}
