using ATS.Cadastro.Domain.Produtos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class CorMap : EntityTypeConfiguration<Cor>
    {
        public CorMap()
        {
            // Chave primaria
            HasKey(cor => cor.IdCor);

            //Propriedades
            Property(cor => cor.IdCor)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(cor => cor.Nome)
                .HasMaxLength(50)
                .IsRequired();

            Property(cor => cor.Observacao);

            Property(cor => cor.Status)
                .HasMaxLength(10)
                .IsRequired();

            //Mapeamento
            ToTable("TB_COR");

            //Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(cor => cor.ListaDeProdutos)
                .WithRequired(prod => prod.Cor);
        }
    }
}
