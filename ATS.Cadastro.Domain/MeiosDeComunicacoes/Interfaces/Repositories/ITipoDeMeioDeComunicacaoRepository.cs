using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Repositories
{
    public interface ITipoDeMeioDeComunicacaoRepository
    {
        TipoDeMeioDeComunicacao ObterPorId(Guid idTipo);

        TipoDeMeioDeComunicacao ObterTipoDeMeioPor(string descricao);

        IEnumerable<TipoDeMeioDeComunicacao> ObterTodosOsTipos();
    }
}
