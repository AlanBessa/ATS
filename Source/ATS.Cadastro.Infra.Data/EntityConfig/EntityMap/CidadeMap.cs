﻿using ATS.Cadastro.Domain.Enderecos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            // Chave primaria
            HasKey(cid => cid.IdCidade);

            //Propriedades
            Property(cid => cid.IdCidade)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            Property(es => es.Nome)
                .HasMaxLength(60)
                .IsRequired();

            //Mapeamento
            ToTable("TB_CIDADE");

            //Relacionamentos
            HasMany(cid => cid.ListaDeEnderecos)
                .WithRequired(e => e.Cidade);

            HasRequired(cid => cid.Estado)
                .WithMany(est => est.ListaDeCidades)
                .HasForeignKey(cid => cid.EstadoId);
        }
    }
}
