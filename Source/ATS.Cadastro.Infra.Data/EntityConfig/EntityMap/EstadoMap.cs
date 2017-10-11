using ATS.Cadastro.Domain.Enderecos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            // Chave primaria
            HasKey(es => es.IdEstado);

            //Propriedades
            Property(es => es.IdEstado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            Property(es => es.Nome)
                .HasMaxLength(50)
                .IsRequired();

            Property(es => es.UF)
                .HasMaxLength(2)
                .IsRequired();

            //Mapeamento
            ToTable("TB_ESTADO");

            //Relacionamentos
            HasMany(es => es.ListaDeCidades)
                .WithRequired(cid => cid.Estado);

            HasMany(es => es.ListaDePessoasFisica)
                .WithOptional(pf => pf.Naturalidade);
        }
    }
}
