using ATS.Cadastro.Domain.Enderecos.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Cadastro.Domain.Enderecos.Entidades;
using ATS.Cadastro.Infra.Data.Context;

namespace ATS.Cadastro.Infra.Data.Repository
{
    public class EstadoRepository : BaseRepository, IEstadoRepository
    {
        private readonly CadastroContext _context;

        public EstadoRepository(CadastroContext context)
        {
            _context = context;
        }

        public IEnumerable<Estado> ObterTodos()
        {
            return _context.Estados.ToList();
        }
    }
}
