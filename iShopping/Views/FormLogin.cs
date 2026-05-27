using iShopping.Controller;
using System;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        // Lógica ligada ao botão "Login" da interface
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var controller = new UtilizadorController();

            bool loginSucesso = controller.EfetuarLogin(textBoxUsername.Text, textBoxPassword.Text);

            if (loginSucesso)
            {

                // Abre a página principal
                FormPrincipal main = new FormPrincipal();
                main.Show();

                // Esconde a janela de login
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username ou Password incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lógica ligada ao botão "Registar Utilizador" da interface de Login

        private void buttonRegistarUtilizador_Click_1(object sender, EventArgs e)
        {
            // AQUI APENAS ABRIMOS A NOVA JANELA!
            FormCriarUtilizador formRegisto = new FormCriarUtilizador();
            formRegisto.ShowDialog();
        }

        private void buttonHideShow_Click(object sender, EventArgs e)
        {

            if (textBoxPassword.PasswordChar == '*')// Verifica se a password está atualmente oculta pelo asterisco
            {
                textBoxPassword.PasswordChar = '\0';// Ao definir como '\0' (caractere nulo), a TextBox passa a mostrar o texto real
                buttonHideShow.Text = "Ocultar"; // Muda o texto do botão
            }
            else
            {
                textBoxPassword.PasswordChar = '*'; // Volta a colocar o asterisco para ocultar o texto
                buttonHideShow.Text = "Mostrar"; // Muda o texto do botão 
            }
        }
    }
}