using ATS.Cadastro.Domain.Enderecos.Entidades;
using DapperExtensions.Mapper;

namespace ATS.Cadastro.Infra.Data.EntityConfig.DapperMap
{
    public class EnderecoDapperMap : ClassMapper<Endereco>
    {
        public EnderecoDapperMap()
        {
            Table("TB_ENDERECO");

            Map(e => e.IdEndereco).Column("IdEndereco").Key(KeyType.Identity);
        }
    }
}
