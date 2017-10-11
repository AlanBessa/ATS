using ATS.Cadastro.Domain.Impostos.Entidades;
using ATS.Cadastro.Domain.Processo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Produtos.Entidades
{
    public class Produto
    {
        #region "Propriedades"

        public Guid IdProduto { get; set; }

        /// <remarks>Max Length 50 - Nullable False</remarks>
        public string Nome { get; private set; }

        /// <remarks>Max Length 15 - Nullable True</remarks>
        public string CodFabrica { get; private set; }

        /// <remarks>Max Length 15 - Nullable True</remarks>
        public string CodNcm { get; private set; }

        /// <remarks>Decimal 9.2 - Nullable True</remarks>
        public decimal TaxaIcms { get; private set; }

        /// <remarks>Decimal 9.2 - Nullable True</remarks>
        public decimal TaxaIpi { get; private set; }

        /// <remarks>Decimal 9.2 - Nullable True</remarks>
        public decimal TaxaSt { get; private set; }

        /// <remarks>Decimal 9.2 - Nullable True</remarks>
        public decimal AliquotaIcms { get; private set; }

        public decimal ReducaoIcms { get; private set; }

        public decimal AliquotaCofins { get; private set; }

        public decimal AliquotaPis { get; private set; }

        public decimal AliquotaIpi { get; private set; }

        public decimal TribMedia { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public DateTime? DataAlteracao { get; private set; }

        public string WebUrl { get; private set; }

        public string Status { get; private set; }

        public string Observacao { get; private set; }

        public Guid? FornecedorId { get; private set; }

        public Fornecedor Fornecedor { get; private set; }

        public Guid? FabricanteId { get; private set; }

        public Fabricante Fabricante { get; private set; }

        public Guid? MarcaId { get; private set; }

        public Marca Marca { get; private set; }

        public Guid? CorId { get; private set; }

        public Cor Cor { get; private set; }

        public Guid? GrupoId { get; private set; }

        public Grupo Grupo { get; private set; }

        public Guid? PisId { get; private set; }

        public Pis Pis { get; private set; }

        public Guid? CofinsId { get; private set; }

        public Cofins Cofins { get; private set; }

        //public Aplicacao Aplicacao { get; private set; }

        public Guid? IpiId { get; private set; }

        public Ipi Ipi { get; private set; }

        public Guid? TributacaoId { get; private set; }

        public Tributacao Tributacao { get; private set; }

        public Guid? SitTributariaId { get; private set; }

        public SitTributaria SitTributaria { get; private set; }

        #endregion

        #region "Metodos"

        #endregion
    }
}
