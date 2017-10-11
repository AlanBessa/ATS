using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Infra.Data.UoW;
using ATS.Cadastro.Application.Interfaces;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Services;
using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Application.Adapters;

namespace ATS.Cadastro.Application
{
    public class TipoDeMeioDeComunicacaoApp : BaseApp, ITipoDeMeioDeComunicacaoApp
    {
        private readonly ITipoDeMeioDeComunicacaoService _tipoDeMeioDeComunicacaoService;

        public TipoDeMeioDeComunicacaoApp(ITipoDeMeioDeComunicacaoService tipoDeMeioDeComunicacaoService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _tipoDeMeioDeComunicacaoService = tipoDeMeioDeComunicacaoService;
        }

        public IEnumerable<TipoDeMeioDeComunicacaoCommands> ObterTodosOsTipos()
        {
            var listaDeTiposDeMeioDeComunicacao = _tipoDeMeioDeComunicacaoService.ObterTodosOsTipos().ToList();

            var listaDeTiposDeMeioDeComunicacaoCommands = new List<TipoDeMeioDeComunicacaoCommands>();

            listaDeTiposDeMeioDeComunicacao.ForEach(m => listaDeTiposDeMeioDeComunicacaoCommands.Add(TipoDeMeioDeComunicacaoAdapter.ToModelDomain(m)));

            return listaDeTiposDeMeioDeComunicacaoCommands;
        }
    }
}
