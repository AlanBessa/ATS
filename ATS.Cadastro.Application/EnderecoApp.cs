using ATS.Cadastro.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Infra.Data.UoW;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Services;
using ATS.Cadastro.Application.Adapters;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Services;

namespace ATS.Cadastro.Application
{
    public class EnderecoApp : BaseApp, IEnderecoApp
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public EnderecoApp(IPessoaFisicaService pessoaFisicaService, IEnderecoService enderecoService, IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            _enderecoService = enderecoService;
            _pessoaFisicaService = pessoaFisicaService;
        }

        public EnderecoCommands CadastrarEndereco(EnderecoCommands enderecoVM)
        {
            var pessoa = _pessoaFisicaService.ObterPorId(enderecoVM.PessoaId.Value);
            var endereco = _enderecoService.Adicionar(EnderecoAdapter.ToDomainModel(enderecoVM));
            pessoa.AdicionarEndereco(endereco);

            _pessoaFisicaService.Atualizar(pessoa);

            if (!Commit()) return null;

            var enderecoRetorno = _enderecoService.ObterPorId(endereco.IdEndereco);

            return EnderecoAdapter.ToModelDomain(enderecoRetorno);
        }

        public void RemoverEndereco(Guid id)
        {
            _enderecoService.Remover(id);

            Commit();
        }
    }
}
