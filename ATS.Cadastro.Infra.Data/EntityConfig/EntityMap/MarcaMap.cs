using ATS.Cadastro.Domain.Produtos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class MarcaMap : EntityTypeConfiguration<Marca>
    {
        public MarcaMap()
        {
            // Chave primaria
            HasKey(mar => mar.IdMarca);

            //Propriedades
            Property(mar => mar.IdMarca)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(mar => mar.Nome)
                .HasMaxLength(50)
                .IsRequired();

            Property(mar => mar.Observacao);

            Property(mar => mar.Status)
                .HasMaxLength(10)
                .IsRequired();

            //Mapeamento
            ToTable("TB_MARCA");

            //Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(mar => mar.ListaDeProdutos)
                .WithRequired(prod => prod.Marca);
        }
    }
}
