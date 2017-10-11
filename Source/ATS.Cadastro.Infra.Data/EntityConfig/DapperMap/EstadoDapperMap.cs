using ATS.Cadastro.Domain.Enderecos.Entidades;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Infra.Data.EntityConfig.DapperMap
{
    public class EstadoDapperMap : ClassMapper<Estado>
    {
        public EstadoDapperMap()
        {
            Table("TB_ESTADO");

            Map(e => e.IdEstado).Column("IdEstado").Key(KeyType.Identity);
        }
    }
}
