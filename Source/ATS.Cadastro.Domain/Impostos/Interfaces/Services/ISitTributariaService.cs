using ATS.Cadastro.Domain.Impostos.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Impostos.Interfaces.Services
{
    public interface ISitTributariaService
    {
        void Adicionar(SitTributaria sitTributaria);

        void Atualizar(SitTributaria sitTributaria);

        void Remover(Guid id);

        SitTributaria ObterPorId(Guid id);

        IEnumerable<SitTributaria> ObterTodos();
    }
}
