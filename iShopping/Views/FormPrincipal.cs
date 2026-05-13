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
            form.ShowDialog();
        }

        //Ligação Buttons ToolStrip
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void artigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestaoArtigos FormGestaoArtigos = new FormGestaoArtigos();
            FormGestaoArtigos.ShowDialog();
        }

        private void tipoDeArtigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestaoTiposArtigo FormGestaoTiposArtigo = new FormGestaoTiposArtigo();
            FormGestaoTiposArtigo.ShowDialog();
        }

        private void orçamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestaoOrcamentos FormGestaoOrcamentos = new FormGestaoOrcamentos();
            FormGestaoOrcamentos.ShowDialog();
        }
        private void estatísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEstatisticas formEstatisticas = new FormEstatisticas();
            formEstatisticas.ShowDialog();
        }

        //Ligação Buttons Acesso Rápido
        private void buttonPlaneamento_Click(object sender, EventArgs e)
        {
            FormPlaneamentoCompras formPlaneamentoCompras = new FormPlaneamentoCompras();
            formPlaneamentoCompras.ShowDialog();
        }

        private void buttonModoCompra_Click(object sender, EventArgs e)
        {
            FormModoCompra formModoCompra = new FormModoCompra();
            formModoCompra.ShowDialog();
        }

        private void buttonArtigos_Click(object sender, EventArgs e)
        {
            FormGestaoArtigos FormGestaoArtigos = new FormGestaoArtigos();
            FormGestaoArtigos.ShowDialog();
        }

        private void buttonOrcamentos_Click(object sender, EventArgs e)
        {
            FormGestaoOrcamentos FormGestaoOrcamentos = new FormGestaoOrcamentos();
            FormGestaoOrcamentos.ShowDialog();
        }

        
    }
}
