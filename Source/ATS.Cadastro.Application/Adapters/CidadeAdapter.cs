using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Domain.Enderecos.Entidades;

namespace ATS.Cadastro.Application.Adapters
{
    public class CidadeAdapter
    {
        public static Cidade ToDomainModel(CidadeCommands cidadeVM)
        {
            var cidade = new Cidade(
                cidadeVM.Nome,
                cidadeVM.EstadoId.Value,
                cidadeVM.IdCidade);

            return cidade;
        }

        public static CidadeCommands ToModelDomain(Cidade cidade)
        {
            var cidadeVM = new CidadeCommands();
            cidadeVM.Nome = cidade.Nome;
            cidadeVM.EstadoId = cidade.EstadoId;
            cidadeVM.IdCidade = cidade.IdCidade;

            return cidadeVM;
        }
    }
}
