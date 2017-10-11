using ATS.Cadastro.Domain.Pessoas.Entidades;
using DapperExtensions.Mapper;

namespace ATS.Cadastro.Infra.Data.EntityConfig.DapperMap
{
    public class PessoaDapperMap : ClassMapper<Pessoa>
    {
        public PessoaDapperMap()
        {
            Table("TB_PESSOA");

            Map(p => p.IdPessoa).Column("IdPessoa").Key(KeyType.Identity);
        }
    }
}
