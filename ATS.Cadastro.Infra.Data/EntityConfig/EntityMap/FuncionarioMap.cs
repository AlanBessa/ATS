using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            // Chave primaria
            HasKey(p => p.IdPessoa);

            //Propriedades
            Property(p => p.IdPessoa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(f => f.CTPS)
                .HasMaxLength(30);

            Property(f => f.DataDaProximaFerias)
                .HasColumnType("DateTime2");

            //Mapeamento
            ToTable("TB_FUNCIONARIO");
            
            //Relacionamentos
            HasMany(f => f.ListaDeHistoricoDeCargos)
                .WithRequired(hc => hc.Funcionario);
        }
    }
}
