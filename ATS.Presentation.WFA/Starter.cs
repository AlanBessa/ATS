using ATS.Cadastro.Application.Interfaces;
using System;
using System.Windows.Forms;

namespace ATS.Presentation.WFA
{
    public partial class Starter : Form
    {
        public Starter()
        {
            InitializeComponent();
        }

        private void SubMenuCadastrosFisica_Click(object sender, EventArgs e)
        {
            //Form myCliente = new PessoaFisica.Cadastro()
            //{
            //    MdiParent = this
            //};
            //myCliente.Show();

            //desabilita menu
            SubMenuCadastrosFisica.Enabled = false;
        }
    }
}
