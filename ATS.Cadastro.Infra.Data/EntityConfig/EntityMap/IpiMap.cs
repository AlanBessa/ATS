using ATS.Cadastro.Domain.Impostos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class IpiMap : EntityTypeConfiguration<Ipi>
    {
        public IpiMap()
        {
            // Chave primaria
            HasKey(ipi => ipi.IdIpi);

            //Propriedades
            Property(ipi => ipi.IdIpi)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ipi => ipi.CodValor)
                .HasMaxLength(50);

            Property(ipi => ipi.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            //Mapeamento
            ToTable("TB_IPI");

            //Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(ipi => ipi.ListaDeProdutos)
                .WithRequired(prod => prod.Ipi);
        }
    }
}
