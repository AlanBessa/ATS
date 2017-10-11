using ATS.Cadastro.Domain.Pessoas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.Processo.Entidades
{
    public abstract class Transportadora
    {
        protected Transportadora()
        {

        }

        //TODO: Adicionar os outros atributos a ser cadastrados no construtor
        public Transportadora(Guid? idTransportadora)
        {
            IdTransportadora = idTransportadora == null ? Guid.NewGuid() : idTransportadora.Value;
        }

        #region "Propriedade"

        public Guid IdTransportadora { get; private set; }

        /// <remarks>Max Length 1 - Nullable False</remarks>
        public int Tipo { get; private set; }
        
        /// <remarks>Decimal 9.2 scala - Nullable False</remarks>
        public decimal LimiteCarga { get; private set; }

        public Guid MotoristaId { get; private set; }

        public PessoaFisica Motorista { get; private set; }

        /// <remarks>Max Length 50 - Nullable False</remarks>
        public string Veiculo { get; private set; }

        /// <remarks>Max Length 8 - Nullable False</remarks>
        public string Placa { get; private set; }

        public Guid AuxiliarId { get; private set; }

        public PessoaFisica Auxiliar { get; private set; }

        /// <remarks>DateTime - Nullable True</remarks>
        public DateTime DataAlteracao { get; private set; }

        /// <remarks>DateTime - Dinamic</remarks>
        public DateTime DataCadastro { get; private set; }

        /// <remarks>Max - Nullable True</remarks>
        public string Observacao { get; private set; }

        #endregion

        #region "Metodo"

        #endregion
    }
}
