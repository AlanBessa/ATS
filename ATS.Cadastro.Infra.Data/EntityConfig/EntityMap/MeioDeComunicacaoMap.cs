using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class MeioDeComunicacaoMap : EntityTypeConfiguration<MeioDeComunicacao>
    {
        public MeioDeComunicacaoMap()
        {
            // Chave primaria
            HasKey(mc => mc.IdMeioDeComunicacao);

            //Propriedades
            Property(mc => mc.IdMeioDeComunicacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(mc => mc.Valor)
                .HasMaxLength(100)
                .IsRequired();

            //Mapeamento
            ToTable("TB_MEIO_COMUNICACAO");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasRequired(mc => mc.TipoDeMeioDeComunicacao)
                .WithMany(tmc => tmc.ListaDeMeioDeComunicacoes)
                .HasForeignKey(mc => mc.TipoDeMeioDeComunicacaoId);

            HasRequired(mc => mc.Pessoa)
                .WithMany(p => p.ListaDeMeioDeComunicacoes)
                .HasForeignKey(mc => mc.PessoaId);
        }
    }
}
