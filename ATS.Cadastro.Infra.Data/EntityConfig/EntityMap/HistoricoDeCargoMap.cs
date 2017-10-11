using ATS.Cadastro.Domain.Funcionarios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class HistoricoDeCargoMap : EntityTypeConfiguration<HistoricoDeCargo>
    {
        public HistoricoDeCargoMap()
        {
            // Chave primaria
            HasKey(hc => hc.IdHistoricoDoCargo);

            //Propriedades
            Property(hc => hc.IdHistoricoDoCargo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(hc => hc.DataDeAdmissao)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(hc => hc.DataDeDemissao)
                .HasColumnType("DateTime2");

            Property(hc => hc.HorarioDeEntrada)
                .HasMaxLength(8)
                .IsRequired();

            Property(hc => hc.HorarioDeSaida)
                .HasMaxLength(8)
                .IsRequired();

            Property(hc => hc.HorarioDeEntradaFimDeSemana)
                .HasMaxLength(8);

            Property(hc => hc.HorarioDeSaidaFimDeSemana)
                .HasMaxLength(8);

            Property(hc => hc.Comissao);

            Property(hc => hc.Salario);

            //Mapeamento
            ToTable("TB_HISTORICO_DE_CARGO");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasRequired(hc => hc.Cargo)
                .WithMany(car => car.ListaDeHistoricosDeCargo)
                .HasForeignKey(hc => hc.CargoId);

            HasRequired(hc => hc.Funcionario)
                .WithMany(f => f.ListaDeHistoricoDeCargos)
                .HasForeignKey(hc => hc.FuncionarioId);
        }
    }
}
