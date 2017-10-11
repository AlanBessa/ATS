using ATS.Cadastro.Domain.Base;
using ATS.Cadastro.Domain.Contatos.Interfaces.Repositories;
using ATS.Cadastro.Domain.Contatos.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ATS.Cadastro.Domain.Contatos.Services
{
    public class ContatoService : BaseService, IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void Adicionar(Contato contato)
        {
            _contatoRepository.Adicionar(contato);
        }

        public void Atualizar(Contato contato)
        {
            _contatoRepository.Atualizar(contato);
        }

        public Contato ObterPorId(Guid id)
        {
            return _contatoRepository.ObterPorId(id);
        }

        public IEnumerable<Contato> ObterTodos()
        {
            return _contatoRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _contatoRepository.Remover(id);
        }
    }
}
