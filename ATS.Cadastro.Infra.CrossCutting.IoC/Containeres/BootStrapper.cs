using ATS.Cadastro.Application;
using ATS.Cadastro.Application.Interfaces;
using ATS.Cadastro.Domain.Agendas.Interfaces.Repositories;
using ATS.Cadastro.Domain.Agendas.Interfaces.Services;
using ATS.Cadastro.Domain.Agendas.Services;
using ATS.Cadastro.Domain.Contatos.Handlers;
using ATS.Cadastro.Domain.Contatos.Interfaces.Eventos;
using ATS.Cadastro.Domain.Contatos.Interfaces.Repositories;
using ATS.Cadastro.Domain.Contatos.Interfaces.Services;
using ATS.Cadastro.Domain.Contatos.Services;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Repositories;
using ATS.Cadastro.Domain.Enderecos.Interfaces.Services;
using ATS.Cadastro.Domain.Enderecos.Services;
using ATS.Cadastro.Domain.Funcionarios.Interfaces.Repositories;
using ATS.Cadastro.Domain.Funcionarios.Interfaces.Services;
using ATS.Cadastro.Domain.Funcionarios.Services;
using ATS.Cadastro.Domain.Impostos.Interfaces.Repositories;
using ATS.Cadastro.Domain.Impostos.Interfaces.Services;
using ATS.Cadastro.Domain.Impostos.Services;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Repositories;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Services;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Services;
using ATS.Cadastro.Domain.Pessoas.Events;
using ATS.Cadastro.Domain.Pessoas.Handlers;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Repositories;
using ATS.Cadastro.Domain.Pessoas.Interfaces.Services;
using ATS.Cadastro.Domain.Pessoas.Services;
using ATS.Cadastro.Domain.Produtos.Interfaces.Repositories;
using ATS.Cadastro.Domain.Produtos.Interfaces.Services;
using ATS.Cadastro.Domain.Produtos.Services;
using ATS.Cadastro.Infra.Data.Context;
using ATS.Cadastro.Infra.Data.Repository;
using ATS.Cadastro.Infra.Data.UoW;
using ATS.Core.Domain.Events;
using ATS.Core.Domain.Handlers;
using ATS.Core.Domain.Interfaces;
using SimpleInjector;

namespace ATS.Cadastro.Infra.CrossCutting.IoC.Containeres
{
    public class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            MyContainer = container;

            // APP
            container.Register<IContatoApp, ContatoApp>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaApp, PessoaFisicaApp>(Lifestyle.Scoped);
            container.Register<ICidadeApp, CidadeApp>(Lifestyle.Scoped);
            container.Register<IEstadoApp, EstadoApp>(Lifestyle.Scoped);
            container.Register<IMeioDeComunicacaoApp, MeioDeComunicacaoApp>(Lifestyle.Scoped);
            container.Register<ITipoDeMeioDeComunicacaoApp, TipoDeMeioDeComunicacaoApp>(Lifestyle.Scoped);
            container.Register<IEnderecoApp, EnderecoApp>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaApp, PessoaJuridicaApp>(Lifestyle.Scoped);

            // Domain
            container.Register<IContatoService, ContatoService>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaService, PessoaFisicaService>(Lifestyle.Scoped);
            container.Register<IEnderecoService, EnderecoService>(Lifestyle.Scoped);
            container.Register<IAgendaService, AgendaService>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaService, PessoaJuridicaService>(Lifestyle.Scoped);
            container.Register<ICargoService, CargoService>(Lifestyle.Scoped);
            container.Register<IFuncionarioService, FuncionarioService>(Lifestyle.Scoped);
            container.Register<IHistoricoDeCargoService, HistoricoDeCargoService>(Lifestyle.Scoped);
            container.Register<ICofinsService, CofinsService>(Lifestyle.Scoped);
            container.Register<ICorService, CorService>(Lifestyle.Scoped);
            container.Register<IFabricanteService, FabricanteService>(Lifestyle.Scoped);
            container.Register<IIpiService, IpiService>(Lifestyle.Scoped);
            container.Register<IMarcaService, MarcaService>(Lifestyle.Scoped);
            container.Register<IPisService, PisService>(Lifestyle.Scoped);
            container.Register<ISitTributariaService, SitTributariaService>(Lifestyle.Scoped);
            container.Register<ITributacaoService, TributacaoService>(Lifestyle.Scoped);
            container.Register<ICidadeService, CidadeService>(Lifestyle.Scoped);
            container.Register<IEstadoService, EstadoService>(Lifestyle.Scoped);
            container.Register<IMeioDeComunicacaoService, MeioDeComunicacaoService>(Lifestyle.Scoped);
            container.Register<ITipoDeMeioDeComunicacaoService, TipoDeMeioDeComunicacaoService>(Lifestyle.Scoped);

            // Infra Dados Repos
            container.Register<IContatoRepository, ContatoRepository>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaRepository, PessoaFisicaRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IAgendaRepository, AgendaRepository>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaRepository, PessoaJuridicaRepository>(Lifestyle.Scoped);
            container.Register<ICargoRepository, CargoRepository>(Lifestyle.Scoped);
            container.Register<IFuncionarioRepository, FuncionarioRepository>(Lifestyle.Scoped);
            container.Register<IHistoricoDeCargoRepository, HistoricoDeCargoRepository>(Lifestyle.Scoped);
            container.Register<ICofinsRepository, CofinsRepository>(Lifestyle.Scoped);
            container.Register<ICorRepository, CorRepository>(Lifestyle.Scoped);
            container.Register<IFabricanteRepository, FabricanteRepository>(Lifestyle.Scoped);
            container.Register<IIpiRepository, IpiRepository>(Lifestyle.Scoped);
            container.Register<IMarcaRepository, MarcaRepository>(Lifestyle.Scoped);
            container.Register<IPisRepository, PisRepository>(Lifestyle.Scoped);
            container.Register<ISitTributariaRepository, SitTributariaRepository>(Lifestyle.Scoped);
            container.Register<ITributacaoRepository, TributacaoRepository>(Lifestyle.Scoped);
            container.Register<ICidadeRepository, CidadeRepository>(Lifestyle.Scoped);
            container.Register<IEstadoRepository, EstadoRepository>(Lifestyle.Scoped);
            container.Register<IMeioDeComunicacaoRepository, MeioDeComunicacaoRepository>(Lifestyle.Scoped);
            container.Register<ITipoDeMeioDeComunicacaoRepository, TipoDeMeioDeComunicacaoRepository>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<CadastroContext>(Lifestyle.Scoped);

            // Handlers
            container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
            container.Register<IHandler<ContatoCadastroEvent>, ContatoCadastradoHandler>(Lifestyle.Scoped);
            container.Register<IHandler<PessoaFisicaCadastradaEvent>, PessoaFisicaCadastradaHandler>(Lifestyle.Scoped);

            // Infra Core
            //container.Register<IEnvioEmail, EnvioEmail>(Lifestyle.Singleton);

            // Identity
            //container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            //container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            //container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            //container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            //container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            //container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }
    }
}
