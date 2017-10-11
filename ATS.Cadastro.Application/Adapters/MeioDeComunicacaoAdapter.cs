using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;

namespace ATS.Cadastro.Application.Adapters
{
    public class MeioDeComunicacaoAdapter
    {
        public static MeioDeComunicacao ToDomainModel(MeioDeComunicacaoCommands meioDeComunicacaoVM, TipoDeMeioDeComunicacao tipoDeMeioDeComunicacao)
        {
            if (meioDeComunicacaoVM == null) return null;

            var meioDeComunicacao = new MeioDeComunicacao (
                meioDeComunicacaoVM.Valor, 
                meioDeComunicacaoVM.PessoaId,
                tipoDeMeioDeComunicacao,
                meioDeComunicacaoVM.IdMeioDeComunicacao);
            
            return meioDeComunicacao;
        }

        public static MeioDeComunicacaoCommands ToModelDomain(MeioDeComunicacao meioDeComunicacao)
        {
            if (meioDeComunicacao == null) return null;

            var meioDeComunicacaoVM = new MeioDeComunicacaoCommands();
            meioDeComunicacaoVM.IdMeioDeComunicacao = meioDeComunicacao.IdMeioDeComunicacao;
            meioDeComunicacaoVM.Valor = meioDeComunicacao.Valor;
            meioDeComunicacaoVM.PessoaId = meioDeComunicacao.PessoaId;
            meioDeComunicacaoVM.TipoDeMeioDeComunicacao = TipoDeMeioDeComunicacaoAdapter.ToModelDomain(meioDeComunicacao.TipoDeMeioDeComunicacao);
            meioDeComunicacaoVM.TipoDeMeioDeComunicacaoId = meioDeComunicacao.TipoDeMeioDeComunicacaoId;

            return meioDeComunicacaoVM;
        }
    }
}
