using ATS.Cadastro.Domain.Pessoas.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            // Chave primaria
            HasKey(p => p.IdPessoa);

            //Propriedades
            Property(p => p.IdPessoa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            Property(p => p.DataDeCadastro)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(p => p.DataDeAlteracao)
                .HasColumnType("DateTime2");

            Property(p => p.LimiteDeCredito);

            Property(p => p.Referencias);

            Property(p => p.Conceito);

            Property(p => p.SPC);

            Property(p => p.Status)
                .IsRequired();

            Property(p => p.Observacao)
                .HasMaxLength(500);

            Property(p => p.DataDaUltimaCompra)
                .HasColumnType("DateTime2");

            //Mapeamento
            ToTable("TB_PESSOA");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(c => c.ListaDeEnderecos)
                .WithMany(e => e.ListaDePessoas)
                .Map(pf =>
                {
                    pf.ToTable("TB_PESSOA_ENDERECO");
                    pf.MapLeftKey("IdPessoa");
                    pf.MapRightKey("IdEndereco");
                });            

            HasMany(p => p.ListaDeMeioDeComunicacoes)
                .WithRequired(mc => mc.Pessoa);
        }
    }
}
