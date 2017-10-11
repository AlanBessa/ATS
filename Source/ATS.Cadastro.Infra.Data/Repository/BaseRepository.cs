using ATS.Cadastro.Infra.Data.EntityConfig.DapperMap;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class BaseRepository
    {
        /// <summary>
        /// Para o uso do Dapper
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["ATSConnectionString"].ConnectionString);
            }
        }

        public static void IniciarMapeamentoDapper()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] 
            {
                typeof(PessoaFisicaDapperMap).Assembly,
                typeof(PessoaJuridicaDapperMap).Assembly,
                typeof(PessoaDapperMap).Assembly,
                typeof(MeioDeComunicacaoDapperMap).Assembly,
                typeof(TipoDeMeioDeComunicacaoDapperMap).Assembly,
                typeof(EnderecoDapperMap).Assembly
            });
        }

        /// <summary>
        /// Para o uso do Ado.Net
        /// </summary>
        public Database AdoConnection
        {
            get
            {
                return new DatabaseProviderFactory().Create("ATSConnectionString");
            }
        }
    }
}
