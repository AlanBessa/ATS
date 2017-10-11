using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Services
{
    public interface IMeioDeComunicacaoService
    {
        MeioDeComunicacao Adicionar(MeioDeComunicacao meioDeComunicacao);

        void Remover(Guid id);

        void RemoverLista(IEnumerable<MeioDeComunicacao> lista);

        MeioDeComunicacao ObterPorId(Guid id);

        IEnumerable<MeioDeComunicacao> ObterTodos();
    }
}
