using ATS.Cadastro.Domain.Produtos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Infra.Data.EntityConfig.EntityMap
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            // Chave primaria
            HasKey(prod => prod.IdProduto);

            //Propriedades
            Property(prod => prod.IdProduto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
