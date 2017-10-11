using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;

namespace ATS.Cadastro.Application.Adapters
{
    public class TipoDeMeioDeComunicacaoAdapter
    {
        public static TipoDeMeioDeComunicacao ToDomainModel(TipoDeMeioDeComunicacaoCommands tipoDeMeioDeComunicacaoVM)
        {
            var tipoDeMeioDeComunicacao = new TipoDeMeioDeComunicacao(
                tipoDeMeioDeComunicacaoVM.Descricao,
                tipoDeMeioDeComunicacaoVM.IdTipoDeMeioDeComunicacao);

            return tipoDeMeioDeComunicacao;
        }

        public static TipoDeMeioDeComunicacaoCommands ToModelDomain(TipoDeMeioDeComunicacao tipoDeMeioDeComunicacao)
        {
            var tipoDeMeioDeComunicacaoVM = new TipoDeMeioDeComunicacaoCommands();
            tipoDeMeioDeComunicacaoVM.IdTipoDeMeioDeComunicacao = tipoDeMeioDeComunicacao.IdTipoDeMeioDeComunicacao;
            tipoDeMeioDeComunicacaoVM.Descricao = tipoDeMeioDeComunicacao.Descricao;
            
            return tipoDeMeioDeComunicacaoVM;
        }
    }
}
