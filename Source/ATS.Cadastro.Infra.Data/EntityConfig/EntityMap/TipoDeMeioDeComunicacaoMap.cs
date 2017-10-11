using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class TipoDeMeioDeComunicacaoMap : EntityTypeConfiguration<TipoDeMeioDeComunicacao>
    {
        public TipoDeMeioDeComunicacaoMap()
        {
            // Chave primaria
            HasKey(tmc => tmc.IdTipoDeMeioDeComunicacao);

            //Propriedades
            Property(tmc => tmc.IdTipoDeMeioDeComunicacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(tmc => tmc.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            //Mapeamento
            ToTable("TB_TIPO_MEIO_COMUNICACAO");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(tmc => tmc.ListaDeMeioDeComunicacoes)
                .WithRequired(mc => mc.TipoDeMeioDeComunicacao);
        }
    }
}
