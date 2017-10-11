using ATS.Cadastro.Domain.Contatos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            // Chave primaria
            HasKey(c => c.IdContato);

            //Propriedades
            Property(c => c.IdContato)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            Property(c => c.Nome)
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.Observacao)
                .HasMaxLength(500);

            //Mapeamento
            ToTable("TB_CONTATO");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasRequired(c => c.PessoaJuridica)
                .WithMany(pj => pj.ListaDeContatos)
                .HasForeignKey(c => c.PessoaJuridicaId);

            HasMany(c => c.ListaDeEnderecos)
                .WithMany(e => e.ListaDeContatos)
                .Map(pf =>
                {
                    pf.ToTable("TB_CONTATO_ENDERECO");
                    pf.MapLeftKey("IdContato");
                    pf.MapRightKey("IdEndereco");
                });
        }
    }
}
