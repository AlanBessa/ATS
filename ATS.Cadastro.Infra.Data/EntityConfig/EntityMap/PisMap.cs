using ATS.Cadastro.Domain.Impostos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class PisMap : EntityTypeConfiguration<Pis>
    {
        public PisMap()
        {
            // Chave primaria
            HasKey(pis => pis.IdPis);

            //Propriedades
            Property(pis => pis.IdPis)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(pis => pis.CodValor)
                .HasMaxLength(50);

            Property(pis => pis.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            //Mapeamento
            ToTable("TB_PIS");

            //Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(pis => pis.ListaDeProdutos)
                .WithRequired(prod => prod.Pis);
        }
    }
}
