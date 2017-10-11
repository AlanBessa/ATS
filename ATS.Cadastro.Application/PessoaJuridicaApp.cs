using ATS.Cadastro.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Infra.Data.UoW;
using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Application.ViewModels.PessoaJuridica;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Services;
using ATS.Cadastro.Application.Adapters;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Services;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Services;

namespace ATS.Cadastro.Application
{
    public class PessoaJuridicaApp : BaseApp, IPessoaJuridicaApp
    {
        private readonly IPessoaJuridicaService _pessoaJuridicaService;
        private readonly IPessoaFisicaService _pessoaFisicaService;
        private readonly IEnderecoService _enderecoService;
        private readonly ITipoDeMeioDeComunicacaoService _tipoDeMeioDeComunicacaoService;
        private readonly IMeioDeComunicacaoService _meioDeComunicacaoService;

        public PessoaJuridicaApp(IPessoaJuridicaService pessoaJuridicaService, IPessoaFisicaService pessoaFisicaService, 
                                 IEnderecoService enderecoService, ITipoDeMeioDeComunicacaoService tipoDeMeioDeComunicacaoService,
                                 IMeioDeComunicacaoService meioDeComunicacaoService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _pessoaJuridicaService = pessoaJuridicaService;
            _pessoaFisicaService = pessoaFisicaService;
            _enderecoService = enderecoService;
            _tipoDeMeioDeComunicacaoService = tipoDeMeioDeComunicacaoService;
            _meioDeComunicacaoService = meioDeComunicacaoService;
        }

        public PessoaJuridicaCommands AtualizarPessoaJuridica(EditarPessoaJuridicaViewModel editarPessoaJuridicaVM)
        {
            var pessoaJuridica = _pessoaJuridicaService.ObterPorId(editarPessoaJuridicaVM.DadosDaPessoaJuridica.IdPessoa);
            
            pessoaJuridica.DataDaUltimaCompra = editarPessoaJuridicaVM.DadosDaPessoaJuridica.DataDaUltimaCompra;
            pessoaJuridica.DefinirCNPJ(editarPessoaJuridicaVM.DadosDaPessoaJuridica.CNPJ);
            pessoaJuridica.DefinirInscricao(editarPessoaJuridicaVM.DadosDaPessoaJuridica.Inscricao);
            pessoaJuridica.DefinirNomeFantasia(editarPessoaJuridicaVM.DadosDaPessoaJuridica.NomeFantasia);
            pessoaJuridica.LimiteDeCredito = string.IsNullOrEmpty(editarPessoaJuridicaVM.DadosDaPessoaJuridica.LimiteDeCredito) ? 0M : Convert.ToDecimal(editarPessoaJuridicaVM.DadosDaPessoaJuridica.LimiteDeCredito);
            pessoaJuridica.Observacao = editarPessoaJuridicaVM.DadosDaPessoaJuridica.Observacao;
            pessoaJuridica.Referencias = editarPessoaJuridicaVM.DadosDaPessoaJuridica.Referencias;
            pessoaJuridica.SPC = editarPessoaJuridicaVM.DadosDaPessoaJuridica.SPC;
            pessoaJuridica.DataDeAlteracao = DateTime.Now;
            pessoaJuridica.DefinirSocioPrincipal(PessoaFisicaAdapter.ToDomainModel(editarPessoaJuridicaVM.DadosDaPessoaJuridica.Socio));
            pessoaJuridica.DefinirSocioPrincipal(editarPessoaJuridicaVM.DadosDaPessoaJuridica.Socio.IdPessoa);

            _pessoaFisicaService.Atualizar(pessoaJuridica.Socio);

            if (editarPessoaJuridicaVM.DadosDaPessoaJuridica.SocioMenor != null)
            {
                if (editarPessoaJuridicaVM.DadosDaPessoaJuridica.SocioMenor.IdPessoa == null)
                {
                    if (!string.IsNullOrEmpty(editarPessoaJuridicaVM.DadosDaPessoaJuridica.SocioMenor.Nome) && editarPessoaJuridicaVM.DadosDaPessoaJuridica.SocioMenor.CPF != null)
                    {
                        pessoaJuridica.DefinirSocioSecundario(PessoaFisicaAdapter.ToDomainModelNoValidation(editarPessoaJuridicaVM.DadosDaPessoaJuridica.SocioMenor));
                        pessoaJuridica.DefinirSocioSecundario(pessoaJuridica.SocioMenor.IdPessoa);
                        _pessoaFisicaService.Adicionar(pessoaJuridica.SocioMenor);
                    }
                }
                else
                {
                    _pessoaFisicaService.Atualizar(pessoaJuridica.SocioMenor);
                }
            }
            

            var pessoaJuridicaRetorno = _pessoaJuridicaService.Atualizar(pessoaJuridica);

            if (!Commit()) return null;

            return PessoaJuridicaAdapter.ToModelDomain(pessoaJuridicaRetorno);
        }

        public PessoaJuridicaCommands CadastrarPessoaJuridica(CadastrarPessoaJuridicaViewModel cadastrarPessoaJuridicaVM)
        {
            var pessoaJuridica = PessoaJuridicaAdapter.ToDomainModel(cadastrarPessoaJuridicaVM.DadosDaPessoaJuridica);

            var socio = PessoaFisicaAdapter.ToDomainModel(cadastrarPessoaJuridicaVM.DadosDaPessoaJuridica.Socio);
            var socioPrincipal = _pessoaFisicaService.Adicionar(socio);

            pessoaJuridica.DefinirSocioPrincipal(socioPrincipal);
            pessoaJuridica.DefinirSocioPrincipal(socioPrincipal.IdPessoa);

            if (cadastrarPessoaJuridicaVM.DadosDeEndereco != null)
            {
                var endereco = EnderecoAdapter.ToDomainModel(cadastrarPessoaJuridicaVM.DadosDeEndereco);
                pessoaJuridica.AdicionarEndereco(endereco);

                _enderecoService.Adicionar(endereco);
            }
                      
            var pessoaJuridicaRetorno = _pessoaJuridicaService.Adicionar(pessoaJuridica);

            if (!string.IsNullOrEmpty(cadastrarPessoaJuridicaVM.Telefone.Valor))
            {
                cadastrarPessoaJuridicaVM.Telefone.PessoaId = pessoaJuridica.IdPessoa;
                var telefone = MeioDeComunicacaoAdapter.ToDomainModel(cadastrarPessoaJuridicaVM.Telefone, _tipoDeMeioDeComunicacaoService.ObterTipoDeMeioPor("TELEFONE"));
                _meioDeComunicacaoService.Adicionar(telefone);
            }

            if (!string.IsNullOrEmpty(cadastrarPessoaJuridicaVM.Celular.Valor))
            {
                cadastrarPessoaJuridicaVM.Celular.PessoaId = pessoaJuridica.IdPessoa;
                var celular = MeioDeComunicacaoAdapter.ToDomainModel(cadastrarPessoaJuridicaVM.Celular, _tipoDeMeioDeComunicacaoService.ObterTipoDeMeioPor("CELULAR"));
                _meioDeComunicacaoService.Adicionar(celular);
            }

            if (!string.IsNullOrEmpty(cadastrarPessoaJuridicaVM.RedeSocial.Valor))
            {
                cadastrarPessoaJuridicaVM.RedeSocial.PessoaId = pessoaJuridica.IdPessoa;
                var redeSocial = MeioDeComunicacaoAdapter.ToDomainModel(cadastrarPessoaJuridicaVM.RedeSocial, _tipoDeMeioDeComunicacaoService.ObterTipoDeMeioPor("REDE SOCIAL"));
                _meioDeComunicacaoService.Adicionar(redeSocial);
            }

            if (!string.IsNullOrEmpty(cadastrarPessoaJuridicaVM.Site.Valor))
            {
                cadastrarPessoaJuridicaVM.Site.PessoaId = pessoaJuridica.IdPessoa;
                var site = MeioDeComunicacaoAdapter.ToDomainModel(cadastrarPessoaJuridicaVM.Site, _tipoDeMeioDeComunicacaoService.ObterTipoDeMeioPor("SITE"));
                _meioDeComunicacaoService.Adicionar(site);
            }

            if (!Commit()) return null;

            return PessoaJuridicaAdapter.ToModelDomain(pessoaJuridicaRetorno);
        }

        public void ExcluirPessoaJuridica(Guid id)
        {
            throw new NotImplementedException();
        }

        public EditarPessoaJuridicaViewModel ObterDadosPessoaJuridica(Guid idPessoa)
        {
            var editarPessoaJuridicaVM = new EditarPessoaJuridicaViewModel();
            var listaDeMeiosDeComunicacoes = new List<MeioDeComunicacaoCommands>();
            var listaDeEnderecos = new List<EnderecoCommands>();

            var pessoaJuridica = _pessoaJuridicaService.ObterPorId(idPessoa);
            pessoaJuridica.DefinirSocioPrincipal(_pessoaFisicaService.ObterPorId(pessoaJuridica.SocioId.Value));

            if (pessoaJuridica.SocioMenorId != null)
            {
                pessoaJuridica.DefinirSocioSecundario(_pessoaFisicaService.ObterPorId(pessoaJuridica.SocioMenorId.Value));
            }            

            pessoaJuridica.ListaDeMeioDeComunicacoes.ToList().ForEach(m => listaDeMeiosDeComunicacoes.Add(MeioDeComunicacaoAdapter.ToModelDomain(m)));
            pessoaJuridica.ListaDeEnderecos.ToList().ForEach(m => listaDeEnderecos.Add(EnderecoAdapter.ToModelDomain(m)));

            editarPessoaJuridicaVM.DadosDaPessoaJuridica = PessoaJuridicaAdapter.ToModelDomain(pessoaJuridica);
            editarPessoaJuridicaVM.ListaDeMeioDeComunicacao = listaDeMeiosDeComunicacoes;
            editarPessoaJuridicaVM.ListaDeEnderecos = listaDeEnderecos;

            return editarPessoaJuridicaVM;
        }

        public PesquisarPessoaJuridicaViewModel PesquisarPessoaJuridica(PesquisarPessoaJuridicaViewModel pesquisarPessoaJuridicaVM)
        {
            var listaDePessoasJuridicas = _pessoaJuridicaService.ObterTodosPorFiltro(pesquisarPessoaJuridicaVM.CNPJ, pesquisarPessoaJuridicaVM.RazaoSocial).ToList();

            var listaDePessoaCommand = new List<PessoaJuridicaCommands>();

            listaDePessoasJuridicas.ForEach(m => listaDePessoaCommand.Add(PessoaJuridicaAdapter.ToModelDomain(m)));

            pesquisarPessoaJuridicaVM.ListaDePessoasJuridicas = listaDePessoaCommand;

            return pesquisarPessoaJuridicaVM;
        }
    }
}
