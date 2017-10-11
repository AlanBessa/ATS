using ATS.Cadastro.Domain.Pessoas.Entidades;
using DapperExtensions.Mapper;

namespace ATS.Cadastro.Infra.Data.EntityConfig.DapperMap
{
    public class PessoaJuridicaDapperMap : ClassMapper<PessoaJuridica>
    {
        public PessoaJuridicaDapperMap()
        {
            Table("TB_PESSOA_JURIDICA");

            Map(pf => pf.IdPessoa).Column("IdPessoa").Key(KeyType.Identity);

            Map(pf => pf.CNPJ.Codigo).Column("CNPJ_Codigo");
        }
    }
}
