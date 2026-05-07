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
            // (Garante que os nomes textBoxUsername e textBoxPassword correspondem às caixas deste formulário!)
            // Validação básica
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            var controller = new iShopping.Controller.UtilizadorController();
            string erro;

            bool sucesso = controller.RegistarUtilizador(textBoxUsername.Text, textBoxPassword.Text, out erro);

            if (sucesso)
            {
                MessageBox.Show("Utilizador criado com sucesso!");
                this.Close(); // Fecha esta janela de registo e volta ao Login
            }
            else
            {
                MessageBox.Show(erro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
