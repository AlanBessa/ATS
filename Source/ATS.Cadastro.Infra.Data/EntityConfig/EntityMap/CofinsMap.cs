using ATS.Cadastro.Domain.Impostos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class CofinsMap : EntityTypeConfiguration<Cofins>
    {
        public CofinsMap()
        {
            // Chave primaria
            HasKey(cof => cof.IdCofins);

            //Propriedades
            Property(cof => cof.IdCofins)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(cof => cof.CodValor)
                .HasMaxLength(50);

            Property(cof => cof.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            //Mapeamento
            ToTable("TB_COFINS");

            //Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(cof => cof.ListaDeProdutos)
                .WithRequired(prod => prod.Cofins);
        }
    }
}
