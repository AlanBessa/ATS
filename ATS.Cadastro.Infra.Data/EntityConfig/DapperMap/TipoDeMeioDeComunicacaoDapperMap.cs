using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Infra.Data.EntityConfig.DapperMap
{
    public class TipoDeMeioDeComunicacaoDapperMap : ClassMapper<TipoDeMeioDeComunicacao>
    {
        public TipoDeMeioDeComunicacaoDapperMap()
        {
            Table("TB_TIPO_MEIO_COMUNICACAO");

            Map(tmc => tmc.IdTipoDeMeioDeComunicacao).Column("IdTipoDeMeioDeComunicacao").Key(KeyType.Identity);
        }
    }
}
