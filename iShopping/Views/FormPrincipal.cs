using iShopping.Controller;
using iShopping.Model;
using iShopping.Views;
using System;
using System.Windows.Forms;

namespace iShopping
{
    public partial class FormPrincipal : Form
    {
        private CompraController _compraController;

        public FormPrincipal()
        {
            InitializeComponent();
            _compraController = new CompraController();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CarregarComprasAbertas();

            // Mostra o utilizador logado no label
            labelUtilizador.Text = "Utilizador: " + UtilizadorController.NomeUtilizadorLogado;
        }

        private void CarregarComprasAbertas()
        {
            try
            {
                listBoxComprasAbertas.DataSource = null;
                listBoxComprasAbertas.DataSource = _compraController.ObterComprasAbertas();
                listBoxComprasAbertas.DisplayMember = "NomeCompra";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAbrirModoCompra_Click(object sender, EventArgs e)
        {
            if (listBoxComprasAbertas.SelectedItem is Compra compraSelecionada)
            {
                FormModoCompra form = new FormModoCompra(compraSelecionada.Id);
                form.ShowDialog();
                CarregarComprasAbertas(); // Atualiza lista após regressar
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma compra da lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Ligação Buttons ToolStrip
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void artigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestaoArtigos formGestaoArtigos = new FormGestaoArtigos();
            formGestaoArtigos.ShowDialog();
        }

        private void tipoDeArtigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestaoTiposArtigo formGestaoTiposArtigo = new FormGestaoTiposArtigo();
            formGestaoTiposArtigo.ShowDialog();
        }

        private void orçamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestaoOrcamentos formGestaoOrcamentos = new FormGestaoOrcamentos();
            formGestaoOrcamentos.ShowDialog();
        }

        private void estatísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEstatisticas formEstatisticas = new FormEstatisticas();
            formEstatisticas.ShowDialog();
        }

        // Ligação Buttons Acesso Rápido
        private void buttonPlaneamento_Click(object sender, EventArgs e)
        {
            FormPlaneamentoCompras formPlaneamentoCompras = new FormPlaneamentoCompras();
            formPlaneamentoCompras.ShowDialog();
            CarregarComprasAbertas(); // Atualiza após voltar do planeamento
        }

        private void buttonModoCompra_Click(object sender, EventArgs e)
        {
                FormCriarEditarCompraPlaneada formCriarEditarCompraPlaneada = new FormCriarEditarCompraPlaneada();
                formCriarEditarCompraPlaneada.ShowDialog();
                CarregarComprasAbertas();
            
            
        }

        private void buttonArtigos_Click(object sender, EventArgs e)
        {
            FormGestaoArtigos formGestaoArtigos = new FormGestaoArtigos();
            formGestaoArtigos.ShowDialog();
        }

        private void buttonOrcamentos_Click(object sender, EventArgs e)
        {
            FormGestaoOrcamentos formGestaoOrcamentos = new FormGestaoOrcamentos();
            formGestaoOrcamentos.ShowDialog();
        }

        private void artigosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGestaoArtigos formGestaoArtigos = new FormGestaoArtigos();
            formGestaoArtigos.ShowDialog();
        }

        
    }
}