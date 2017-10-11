using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Application.Interfaces;
using ATS.Cadastro.Application.ViewModels.PessoaFisica;
using ATS.Core.Domain.ValueObjects;
using ATS.Presentation.WFA.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS.Presentation.WFA.PessoaFisica
{
    public partial class Cadastro : Form
    {
        private readonly IPessoaFisicaApp _pessoaFisicaApp;
        private readonly BaseForm _baseForm;
        
        public Cadastro(IPessoaFisicaApp pessoaFisicaApp)
        {
            _pessoaFisicaApp = pessoaFisicaApp;

            _baseForm = new BaseForm();

            this.ClientSize = new System.Drawing.Size(784, 562);
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var pessoaCommands = new PessoaFisicaCommands();
            pessoaCommands.Status = "Ativo";
            pessoaCommands.Nome = "Alan Bessa";
            pessoaCommands.CPF = "519.249.282-30";
            pessoaCommands.RG = "2324234342";
            pessoaCommands.DataDeNascimento = new DateTime(1988, 12, 10);
            pessoaCommands.NaturalidadeId = new Guid("CFF28DC0-512D-479E-9384-6009042E38C5");
            pessoaCommands.Nacionalidade = "brasileiro";
            pessoaCommands.Sexo = (int)ESexo.Masculino;
            pessoaCommands.EstadoCivil = EEstadoCivil.Solteiro;

            var enderecoCommands = new EnderecoCommands();
            enderecoCommands.Bairro = "Centro";
            enderecoCommands.Cep = "23456-098";
            enderecoCommands.CidadeId = new Guid("A4F98328-BA72-48B2-85EF-A4D920CD9185");
            enderecoCommands.Complemento = string.Empty;
            enderecoCommands.EstadoId = new Guid("CFF28DC0-512D-479E-9384-6009042E38C5");
            enderecoCommands.Logradouro = "Rua Siclano da Silva";
            enderecoCommands.Numero = "1234";



            var cadastroPessoaFisica = new CadastrarPessoaFisicaViewModel();
            cadastroPessoaFisica.DadosDeEndereco = enderecoCommands;
            cadastroPessoaFisica.DadosDaPessoaFisica = pessoaCommands;

            _pessoaFisicaApp.CadastrarPessoaFisica(cadastroPessoaFisica);

            _baseForm.ValidarErrosDominio();
        }
    }
}
