using ATS.Cadastro.Domain.Pessoas.Entidades;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Pessoas.Interfaces.Services
{
    public interface IPessoaJuridicaService
    {
        PessoaJuridica Adicionar(PessoaJuridica pessoaJuridica);

        PessoaJuridica Atualizar(PessoaJuridica pessoaJuridica);

        void Remover(Guid id);

        PessoaJuridica ObterPorId(Guid? id);

        PessoaJuridica ObterPorId(Guid id);
        
        IEnumerable<PessoaJuridica> ObterTodos();
        
        IEnumerable<PessoaJuridica> ObterTodosPorFiltro(string cnpj, string razaoSocial);
    }
}
