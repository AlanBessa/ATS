using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Services
{
    public interface ITributacaoService
    {
        void Adicionar(Tributacao tributacao);

        void Atualizar(Tributacao tributacao);

        void Remover(Guid id);

        Tributacao ObterPorId(Guid id);

        IEnumerable<Tributacao> ObterTodos();
    }
}
