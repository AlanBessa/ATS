using ATS.Cadastro.Domain.Impostos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class TributacaoMap : EntityTypeConfiguration<Tributacao>
    {
        public TributacaoMap()
        {
            // Chave primaria
            HasKey(trib => trib.IdTributacao);

            //Propriedades
            Property(trib => trib.IdTributacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(trib => trib.CodValor)
                .HasMaxLength(50);

            Property(trib => trib.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            //Mapeamento
            ToTable("TB_TRIBUTACAO");

            //Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(trib => trib.ListaDeProdutos)
                .WithRequired(prod => prod.Tributacao);
        }
    }
}
