using ATS.Cadastro.Domain.Agendas.Entidades;
using ATS.Cadastro.Domain.Contatos;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Domain.Funcionarios.Entidades;
using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Cadastro.Domain.Produtos.Entidades;
using ATS.Cadastro.Infra.Data.EntityConfig.EntityMap;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ATS.Cadastro.Infra.Data.Context
{
    public class CadastroContext : DbContext
    {
        public CadastroContext()
            : base("ATSConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<HistoricoDeCargo> HistoricosDeCargo { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<MeioDeComunicacao> MeiosDeComunicacao { get; set; }
        public DbSet<TipoDeMeioDeComunicacao> TiposDeMeioDeComunicacao { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Cofins> Cofinses { get; set; }
        public DbSet<Ipi> Ipis { get; set; }
        public DbSet<Pis> Pises { get; set; }
        public DbSet<SitTributaria> SitTributarias { get; set; }
        public DbSet<Tributacao> Tributacoes { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
               .Where(p => p.Name == "Id" + p.ReflectedType.Name)
               .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new PessoaFisicaMap());
            modelBuilder.Configurations.Add(new PessoaJuridicaMap());
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new HistoricoDeCargoMap());
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new MeioDeComunicacaoMap());
            modelBuilder.Configurations.Add(new TipoDeMeioDeComunicacaoMap());
            modelBuilder.Configurations.Add(new AgendaMap());
            modelBuilder.Configurations.Add(new FabricanteMap());
            modelBuilder.Configurations.Add(new MarcaMap());
            modelBuilder.Configurations.Add(new CorMap());
            modelBuilder.Configurations.Add(new TributacaoMap());
            modelBuilder.Configurations.Add(new SitTributariaMap());
            modelBuilder.Configurations.Add(new PisMap());
            modelBuilder.Configurations.Add(new IpiMap());
            modelBuilder.Configurations.Add(new CofinsMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new EntradaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
