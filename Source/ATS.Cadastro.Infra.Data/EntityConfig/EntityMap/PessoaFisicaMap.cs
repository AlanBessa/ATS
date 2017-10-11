using ATS.Cadastro.Domain.Pessoas.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class PessoaFisicaMap : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            // Chave primaria
            HasKey(p => p.IdPessoa);

            //Propriedades
            Property(p => p.IdPessoa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 

            Property(pf => pf.Nome)
                .HasMaxLength(200)
                .IsRequired();

            Property(pf => pf.CPF.Codigo)
                .HasMaxLength(11)
                .IsRequired();

            Property(pf => pf.RG);

            Property(pf => pf.TituloEleitor);

            Property(pf => pf.DataDeNascimento)
                .HasColumnType("DateTime2")
                .IsRequired();            

            Property(pf => pf.NomeDoPai)
                .HasMaxLength(200);

            Property(pf => pf.NomeDaMae)
                .HasMaxLength(200);

            Property(pf => pf.Nacionalidade)
                .HasMaxLength(60);

            Property(pf => pf.Observacao)
                .HasMaxLength(500);

            Property(pf => pf.DataDaUltimaCompra)
                .HasColumnType("DateTime2");
            
            //Mapeamento
            ToTable("TB_PESSOA_FISICA");
            
            //Relacionamentos
            HasOptional(pf => pf.Naturalidade)
                .WithMany(e => e.ListaDePessoasFisica)
                .HasForeignKey(pf => pf.NaturalidadeId);
        }
    }
}
