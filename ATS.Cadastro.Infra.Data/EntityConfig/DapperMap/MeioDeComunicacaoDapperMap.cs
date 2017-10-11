using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Infra.Data.EntityConfig.DapperMap
{
    public class MeioDeComunicacaoDapperMap : ClassMapper<MeioDeComunicacao>
    {
        public MeioDeComunicacaoDapperMap()
        {
            Table("TB_MEIO_COMUNICACAO");

            Map(mc => mc.IdMeioDeComunicacao).Column("IdMeioDeComunicacao").Key(KeyType.Identity);
        }
    }
}
