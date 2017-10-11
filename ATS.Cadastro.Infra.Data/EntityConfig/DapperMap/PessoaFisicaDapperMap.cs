using ATS.Cadastro.Domain.Pessoas.Entidades;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Infra.Data.EntityConfig.DapperMap
{
    public class PessoaFisicaDapperMap : ClassMapper<PessoaFisica>
    {
        public PessoaFisicaDapperMap()
        {
            Table("TB_PESSOA_FISICA");

            Map(pf => pf.IdPessoa).Column("IdPessoa").Key(KeyType.Identity);

            Map(pf => pf.CPF.Codigo).Column("CPF_Codigo");
        }
    }
}
