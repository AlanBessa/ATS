using ATS.Cadastro.Application.Commands;
using System.Collections.Generic;

namespace ATS.Cadastro.Application.Interfaces
{
    public interface ITipoDeMeioDeComunicacaoApp
    {
        IEnumerable<TipoDeMeioDeComunicacaoCommands> ObterTodosOsTipos();
    }
}
