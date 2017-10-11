using ATS.Cadastro.Domain.Enderecos.Entidades;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Infra.Data.EntityConfig.DapperMap
{
    public class CidadeDapperMap : ClassMapper<Cidade>
    {
        public CidadeDapperMap()
        {
            Table("TB_CIDADE");

            Map(c => c.IdCidade).Column("IdCidade").Key(KeyType.Identity);
        }
    }
}
