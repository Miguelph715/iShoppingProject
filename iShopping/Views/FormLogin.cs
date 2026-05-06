using iShopping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormLogin: Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (username == "abc" && password == "123")
            {
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Username ou palavra-passe incorretos.");
            }
        }

        private void buttonRegistarUtilizador_Click(object sender, EventArgs e)
        {
            FormCriarUtilizador form = new FormCriarUtilizador();
            //Pus ShowDialog para não deixar mexer noutras páginas
            //enquanto a página Criar Utilizador estiver aberta
            form.ShowDialog();
        }         
    }
}
