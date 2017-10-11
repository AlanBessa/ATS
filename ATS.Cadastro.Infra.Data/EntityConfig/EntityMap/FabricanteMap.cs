using ATS.Cadastro.Domain.Produtos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class FabricanteMap : EntityTypeConfiguration<Fabricante>
    {
        public FabricanteMap()
        {
            // Chave primaria
            HasKey(fab => fab.IdFabricante);

            //Propriedades
            Property(fab => fab.IdFabricante)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(fab => fab.Nome)
                .HasMaxLength(50)
                .IsRequired();

            Property(fab => fab.Observacao);

            Property(cor => cor.Status)
                .HasMaxLength(10)
                .IsRequired();

            //Mapeamento
            ToTable("TB_FABRICANTE");

            //Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(fab => fab.ListaDeProdutos)
                .WithRequired(prod => prod.Fabricante);
        }
    }
}
