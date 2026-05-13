using iShopping.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping
{
    public partial class FormPrincipal: Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }






        private void buttonAbrirModoCompra_Click(object sender, EventArgs e)
        {
            /*if (listBoxComprasAbertas.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma compra primeiro!");
                return;
            }*/

            FormModoCompra form = new FormModoCompra();
            form.Show();
        }

        private void tiposDeArtigosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGestaoTiposArtigo formGestaoTiposArtigo = new FormGestaoTiposArtigo();
            formGestaoTiposArtigo.Show();
        }

        private void estatísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEstatisticas formEstatisticas = new FormEstatisticas();
            formEstatisticas.Show();
        }

        private void artigosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGestaoArtigos formGestaoArtigos = new FormGestaoArtigos();
            formGestaoArtigos.Show();
        }
    }
}
