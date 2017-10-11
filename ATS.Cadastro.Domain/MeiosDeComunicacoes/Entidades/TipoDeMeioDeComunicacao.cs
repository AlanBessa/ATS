using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades
{
    public class TipoDeMeioDeComunicacao
    {
        protected TipoDeMeioDeComunicacao()
        {
        }

        public TipoDeMeioDeComunicacao(string descricao, Guid? idTipoDeMeioDeComunicacao)
        {
            IdTipoDeMeioDeComunicacao = idTipoDeMeioDeComunicacao == null ? Guid.NewGuid() : idTipoDeMeioDeComunicacao.Value;
            Descricao = descricao;
        }

        #region "Propriedades"
        public Guid IdTipoDeMeioDeComunicacao { get; private set; }

        public string Descricao { get; private set; }

        public ICollection<MeioDeComunicacao> ListaDeMeioDeComunicacoes { get; private set; }

        public ValidationResult ValidationResult { get; set; }
        #endregion
    }
}
