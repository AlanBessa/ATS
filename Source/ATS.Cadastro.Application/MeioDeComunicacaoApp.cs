using ATS.Cadastro.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ATS.Cadastro.Infra.Data.UoW;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Services;
using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using ATS.Cadastro.Application.Adapters;

namespace ATS.Cadastro.Application
{
    public class MeioDeComunicacaoApp : BaseApp, IMeioDeComunicacaoApp
    {
        public readonly IMeioDeComunicacaoService _meioDeComunicacaoService;
        public readonly ITipoDeMeioDeComunicacaoService _tipoDeMeioDeComunicacaoService;

        public MeioDeComunicacaoApp(IMeioDeComunicacaoService meioDeComunicacaoService, ITipoDeMeioDeComunicacaoService tipoDeMeioDeComunicacaoService,
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _meioDeComunicacaoService = meioDeComunicacaoService;
            _tipoDeMeioDeComunicacaoService = tipoDeMeioDeComunicacaoService;
        }

        public MeioDeComunicacaoCommands CadastrarMeioDeComunicacao(string valor, Guid idTipoDeMeioDeComunicacao, Guid idPessoa)
        {
            var tipoDeMeioDeComunicacao = _tipoDeMeioDeComunicacaoService.ObterPorId(idTipoDeMeioDeComunicacao);

            var meioDeComunicacao = new MeioDeComunicacao(valor, idPessoa, tipoDeMeioDeComunicacao, null);

            _meioDeComunicacaoService.Adicionar(meioDeComunicacao);

            if (!Commit()) return null;

            return MeioDeComunicacaoAdapter.ToModelDomain(meioDeComunicacao);
        }

        public void Remover(Guid id)
        {
            _meioDeComunicacaoService.Remover(id);

            Commit();
        }
    }
}
