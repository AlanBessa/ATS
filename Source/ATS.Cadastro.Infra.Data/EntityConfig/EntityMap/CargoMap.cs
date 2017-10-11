using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class CargoMap : EntityTypeConfiguration<Cargo>
    {
        public CargoMap()
        {
            // Chave primaria
            HasKey(car => car.IdCargo);

            //Propriedades
            Property(car => car.IdCargo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(car => car.Nome)
                .HasMaxLength(30)
                .IsRequired();

            Property(car => car.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            //Mapeamento
            ToTable("TB_CARGO");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(car => car.ListaDeHistoricosDeCargo)
                .WithRequired(hc => hc.Cargo);
        }
    }
}
