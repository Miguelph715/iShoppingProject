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
    public partial class FormCriarUtilizador: Form
    {
        public FormCriarUtilizador()
        {
            InitializeComponent();
        }
        
        private void buttonCriarUtilizador_Click(object sender, EventArgs e)
        { 
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) )
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            MessageBox.Show("Utilizador criado com sucesso!");

            this.Close();
        }
    }
}
