using ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Cadastro.Domain.MeiosDeComunicacoes.Interfaces.Repositories
{
    public interface IMeioDeComunicacaoRepository
    {
        void Adicionar(MeioDeComunicacao meioDeComunicacao);

        void Atualizar(MeioDeComunicacao meioDeComunicacao);

        void Remover(Guid id);

        MeioDeComunicacao ObterPorId(Guid id);

        IEnumerable<MeioDeComunicacao> ObterTodos();

        IEnumerable<MeioDeComunicacao> Buscar(Expression<Func<MeioDeComunicacao, bool>> predicate);
    }
}
