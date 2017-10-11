using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Produtos.Entidades
{
    public class ItemProduto
    {
        #region "Propriedades"

        public Guid IdItemProduto { get; private set; }
         
        /// <remarks>Max Length 50 - Nullable True</remarks>
        public string Referencia { get; private set; }
        
        /// <remarks>Max Length 3 - Nullable True</remarks>
        public string UniSaida { get; private set; }

        /// <remarks>Max Length 3 - Nullable True</remarks>
        public string UniEntrada { get; private set; }
        
        /// <remarks>Max Length 13 - Nullable True</remarks>
        public string CodBarras { get; private set; }
        
        /// <remarks>Max Length 15 - Nullable True</remarks>
        public string Excessao { get; private set; }

        /// <remarks>Decimal 9.2 scala - Nullable True</remarks>
        public decimal ValorInicial { get; private set; }

        /// <remarks>Decimal 9 escala 2 - Nullable True</remarks>
        public decimal ValorCompra { get; private set; }

        /// <remarks>Decimal 9 escala 2 - Nullable True</remarks>
        public decimal ValorCusto { get; private set; }

        public decimal ValorMedio { get; private set; }

        /// <remarks>Decimal 9 escala 2 - Nullable False</remarks>
        public decimal ValorVenda { get; private set; }

        /// <remarks>Decimal 9 escala 2 - Nullable True</remarks>
        public decimal ValorDesconto { get; private set; }

        /// <remarks>Decimal 9 escala 2 - Nullable True</remarks>
        public decimal IndiceGanho { get; private set; }

        /// <remarks>Decimal 9 escala 2 - Nullable True</remarks>
        public decimal ValorComissao { get; private set; }
                
        public DateTime DataInicio { get; private set; }

        public decimal SaldoInicial { get; private set; }

        public decimal SaldoAtual { get; private set; }
        
        public decimal PesoLiquido { get; private set; }

        public decimal PesoBruto { get; private set; }

        public string Status { get; private set; }

        public string Observacao { get; private set; }
       
        public Guid? TamanhoValorId { get; private set; }

        public TamanhoValor TamanhoValor { get; private set; }
        
        #endregion

        #region "Métodos"

        #endregion
    }
}
