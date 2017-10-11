using ATS.Cadastro.Domain.Pessoas.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class PessoaJuridicaMap : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            // Chave primaria
            HasKey(p => p.IdPessoa);

            //Propriedades
            Property(p => p.IdPessoa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            Property(pj => pj.RazaoSocial)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.DataDeCriacao)
                .HasColumnType("DateTime2")
                .IsRequired();                       

            Property(pj => pj.NomeFantasia)
                .HasMaxLength(200)
                .IsRequired();

            Property(pj => pj.CNPJ.Codigo)
                .HasMaxLength(14)
                .IsRequired();

            Property(pj => pj.Inscricao);

            //Mapeamento
            ToTable("TB_PESSOA_JURIDICA");


            //Relacionamentos
            HasMany(pj => pj.ListaDeContatos)
                .WithRequired(c => c.PessoaJuridica);

            HasRequired(pj => pj.Socio)
                .WithMany(pf => pf.ListaDeSocios)
                .HasForeignKey(pj => pj.SocioId);

            HasOptional(pj => pj.SocioMenor)
                .WithMany(pf => pf.ListaDeSociosMenores)
                .HasForeignKey(pj => pj.SocioMenorId);
        }
    }
}
