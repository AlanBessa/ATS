using ATS.Cadastro.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Cadastro.Application.Interfaces
{
    public interface IMeioDeComunicacaoApp
    {
        MeioDeComunicacaoCommands CadastrarMeioDeComunicacao(string valor, Guid idTipoDeMeioDeComunicacao, Guid idPessoa);

        void Remover(Guid id);
    }
}
