using ATS.Cadastro.Application.Interfaces;
using ATS.Cadastro.Infra.Data.UoW;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Services;
using ATS.Cadastro.Application.ViewModels.PessoaFisica;
using ATS.Cadastro.Application.Adapters;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Services;
using System;
using System.Linq;
using ATS.Cadastro.Application.Commands;
using System.Collections.Generic;
using ATS.Core.Domain.ValueObjects;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Services;

namespace ATS.Cadastro.Application
{
    public class PessoaFisicaApp : BaseApp, IPessoaFisicaApp
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;
        private readonly IEnderecoService _enderecoService;
        private readonly ITipoDeMeioDeComunicacaoService _tipoDeMeioDeComunicacao;
        private readonly IMeioDeComunicacaoService _meioDeComunicacao;

        public PessoaFisicaApp(IPessoaFisicaService pessoaFisicaService, IEnderecoService enderecoService, ITipoDeMeioDeComunicacaoService tipoDeMeioDeComunicacao,
                               IMeioDeComunicacaoService meioDeComunicacao, IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            _pessoaFisicaService = pessoaFisicaService;
            _enderecoService = enderecoService;
            _tipoDeMeioDeComunicacao = tipoDeMeioDeComunicacao;
            _meioDeComunicacao = meioDeComunicacao;
        }
        
        public PessoaFisicaCommands CadastrarPessoaFisica(CadastrarPessoaFisicaViewModel cadastrarPessoaFisicaVM)
        {
            var pessoa = PessoaFisicaAdapter.ToDomainModel(cadastrarPessoaFisicaVM.DadosDaPessoaFisica);           
            
            if(cadastrarPessoaFisicaVM.DadosDeEndereco != null)
            {
                var endereco = EnderecoAdapter.ToDomainModel(cadastrarPessoaFisicaVM.DadosDeEndereco);
                pessoa.AdicionarEndereco(endereco);

                _enderecoService.Adicionar(endereco);
            }            
            
            var pessoaFisica = _pessoaFisicaService.Adicionar(pessoa);
            
            if (!string.IsNullOrEmpty(cadastrarPessoaFisicaVM.Telefone.Valor))
            {
                cadastrarPessoaFisicaVM.Telefone.PessoaId = pessoa.IdPessoa;
                var telefone = MeioDeComunicacaoAdapter.ToDomainModel(cadastrarPessoaFisicaVM.Telefone, _tipoDeMeioDeComunicacao.ObterTipoDeMeioPor("TELEFONE"));
                _meioDeComunicacao.Adicionar(telefone);
            }

            if (!string.IsNullOrEmpty(cadastrarPessoaFisicaVM.Celular.Valor))
            {
                cadastrarPessoaFisicaVM.Celular.PessoaId = pessoa.IdPessoa;
                var celular = MeioDeComunicacaoAdapter.ToDomainModel(cadastrarPessoaFisicaVM.Celular, _tipoDeMeioDeComunicacao.ObterTipoDeMeioPor("CELULAR"));
                _meioDeComunicacao.Adicionar(celular);
            }

            if (!string.IsNullOrEmpty(cadastrarPessoaFisicaVM.RedeSocial.Valor))
            {
                cadastrarPessoaFisicaVM.RedeSocial.PessoaId = pessoa.IdPessoa;
                var redeSocial = MeioDeComunicacaoAdapter.ToDomainModel(cadastrarPessoaFisicaVM.RedeSocial, _tipoDeMeioDeComunicacao.ObterTipoDeMeioPor("REDE SOCIAL"));
                _meioDeComunicacao.Adicionar(redeSocial);
            }

            if (!string.IsNullOrEmpty(cadastrarPessoaFisicaVM.Site.Valor))
            {
                cadastrarPessoaFisicaVM.Site.PessoaId = pessoa.IdPessoa;
                var site = MeioDeComunicacaoAdapter.ToDomainModel(cadastrarPessoaFisicaVM.Site, _tipoDeMeioDeComunicacao.ObterTipoDeMeioPor("SITE"));
                _meioDeComunicacao.Adicionar(site);
            }

            if (!Commit()) return null;

            return PessoaFisicaAdapter.ToModelDomain(pessoaFisica);
        }

        public PessoaFisicaCommands AtualizarPessoaFisica(EditarPessoaFisicaViewModel editarPessoaFisicaVM)
        {
            var pessoaFisica = PessoaFisicaAdapter.ToDomainModel(editarPessoaFisicaVM.DadosDaPessoaFisica);
            pessoaFisica.DataDeAlteracao = DateTime.Now;

            var pessoaFisicaRetorno = _pessoaFisicaService.Atualizar(pessoaFisica);

            if (!Commit()) return null;

            return PessoaFisicaAdapter.ToModelDomain(pessoaFisicaRetorno);
        }

        public EditarPessoaFisicaViewModel ObterDadosPessoaFisica(Guid idPessoa)
        {
            var editarPessoaFisicaVM = new EditarPessoaFisicaViewModel();
            var listaDeMeiosDeComunicacoes = new List<MeioDeComunicacaoCommands>();
            var listaDeEnderecos = new List<EnderecoCommands>();

            var pessoaFisica = _pessoaFisicaService.ObterPorId(idPessoa);

            pessoaFisica.ListaDeMeioDeComunicacoes.ToList().ForEach(m => listaDeMeiosDeComunicacoes.Add(MeioDeComunicacaoAdapter.ToModelDomain(m)));
            pessoaFisica.ListaDeEnderecos.ToList().ForEach(m => listaDeEnderecos.Add(EnderecoAdapter.ToModelDomain(m)));

            editarPessoaFisicaVM.DadosDaPessoaFisica = PessoaFisicaAdapter.ToModelDomain(pessoaFisica);
            editarPessoaFisicaVM.ListaDeMeioDeComunicacao = listaDeMeiosDeComunicacoes;
            editarPessoaFisicaVM.ListaDeEnderecos = listaDeEnderecos;

            return editarPessoaFisicaVM;
        }

        public PesquisarPessoaFisicaViewModel PesquisarPessoaFisica(PesquisarPessoaFisicaViewModel pesquisarPessoaFisicaVM)
        {
            var listaDePessoasFisicas = _pessoaFisicaService.ObterTodosPorFiltro(pesquisarPessoaFisicaVM.CPF, pesquisarPessoaFisicaVM.Nome).ToList();

            var listaDePessoaCommand = new List<PessoaFisicaCommands>();

            listaDePessoasFisicas.ForEach(m => listaDePessoaCommand.Add(PessoaFisicaAdapter.ToModelDomain(m)));

            pesquisarPessoaFisicaVM.ListaDePessoasFisicas = listaDePessoaCommand;

            return pesquisarPessoaFisicaVM;
        }
        
        public void ExcluirPessoaFisica(Guid id)
        {
            var pessoaFisica = _pessoaFisicaService.ObterPorId(id);

            //Excluir Meios de comunicação
            _meioDeComunicacao.RemoverLista(pessoaFisica.ListaDeMeioDeComunicacoes);

            //Excluir endereços
            _enderecoService.RemoverLista(pessoaFisica.ListaDeEnderecos);

            //Excluir PessoaFisica e Pessoa
            _pessoaFisicaService.Remover(pessoaFisica.IdPessoa);

            Commit();
        }

        public IEnumerable<EEstadoCivil> ObterTodosOsEstadosCivis()
        {
            return _pessoaFisicaService.ObterTodosOsEstadosCivis();
        }
    }
}
