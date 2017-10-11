using ATS.Cadastro.Domain.Processo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class EntradaMap : EntityTypeConfiguration<Entrada>
    {
        public EntradaMap()
        {
            // Chave primaria
            HasKey(ent => ent.IdEntrada);

            //Propriedades
            Property(ent => ent.IdEntrada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
