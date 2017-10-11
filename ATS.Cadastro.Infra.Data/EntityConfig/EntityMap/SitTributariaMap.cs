using ATS.Cadastro.Domain.Impostos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class SitTributariaMap : EntityTypeConfiguration<SitTributaria>
    {
        public SitTributariaMap()
        {
            // Chave primaria
            HasKey(st => st.IdSitTibutaria);

            //Propriedades
            Property(st => st.IdSitTibutaria)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(st => st.CodValor)
                .HasMaxLength(50);

            Property(st => st.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            //Mapeamento
            ToTable("TB_SIT_TRIBUTARIA");

            //Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(st => st.ListaDeProdutos)
                .WithRequired(prod => prod.SitTributaria);
        }
    }
}
