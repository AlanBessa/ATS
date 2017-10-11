﻿using ATS.Cadastro.Domain.Enderecos.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            // Chave primaria
            HasKey(e => e.IdEndereco);

            //Propriedades
            Property(e => e.IdEndereco)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Logradouro)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.Numero)
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.Bairro)
                .HasMaxLength(80)
                .IsRequired();

            Property(p => p.Complemento)
                .HasMaxLength(200);

            Property(p => p.Cep.CepCod)
                .HasMaxLength(8)
                .IsRequired();

            //Mapeamento
            ToTable("TB_ENDERECO");

            Ignore(c => c.ValidationResult);

            //Relacionamentos
            HasRequired(e => e.Estado)
                .WithMany(est => est.ListaDeEnderecos)
                .HasForeignKey(e => e.EstadoId);

            HasRequired(e => e.Cidade)
                .WithMany(cid => cid.ListaDeEnderecos)
                .HasForeignKey(e => e.CidadeId);
        }
    }
}
