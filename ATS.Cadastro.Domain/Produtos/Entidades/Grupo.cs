using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Produtos.Entidades
{
    public class Grupo
    {
        #region "Propriedades"
        public Guid IdGrupo { get; private set; }

        public decimal Acrescimo { get; private set; }

        public string Atualizar { get; private set; }

        /// <remarks>Max Length 50 - Nullable False</remarks>
        public string Nome { get; private set; }

        /// <remarks>Max - Nullable True</remarks>
        public string Observacao { get; private set; }
        
        /// <remarks>Max Length 10 - Nullable True</remarks>
        public string Status { get; private set; }

        /// <remarks>Decimal 9.2 scala - Nullable True</remarks>
        public decimal Desconto { get; private set; }

        /// <remarks>DateTime - Nullable True</remarks>
        public DateTime DataAlteracao { get; private set; }

        /// <remarks>DateTime - Dinamic</remarks>
        public DateTime DataCadastro { get; private set; }
        #endregion

        #region "Métodos"

        #endregion
    }
}
