using ATS.Cadastro.Domain.Agendas.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class AgendaMap : EntityTypeConfiguration<Agenda>
    {
        public AgendaMap()
        {
            // Chave primaria
            HasKey(ag => ag.IdAgenda);

            //Propriedades
            Property(ag => ag.IdAgenda)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ag => ag.Titulo)
                .HasMaxLength(50)
                .IsRequired();

            Property(ag => ag.Status)
                .HasMaxLength(10);

            Property(ag => ag.DataCadastro)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(ag => ag.DataAlteracao)
                .HasColumnType("DateTime2");

            Property(ag => ag.DataInicio)
                .HasColumnType("DateTime2");

            Property(ag => ag.DataFim)
                .HasColumnType("DateTime2");

            //Mapeamento
            ToTable("TB_AGENDA");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasMany(ag => ag.ListaDeEnderecos)
                .WithMany(e => e.ListaDeAgendas)
                .Map(pf =>
                {
                    pf.ToTable("TB_AGENDA_ENDERECO");
                    pf.MapLeftKey("IdAgenda");
                    pf.MapRightKey("IdEndereco");
                });
        }
    }
}
