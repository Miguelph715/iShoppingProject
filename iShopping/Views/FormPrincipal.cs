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

            // Mostra o utilizador logado no label (Assumindo que tens a classe UtilizadorController configurada)
            labelUtilizador.Text = "Utilizador: " + UtilizadorController.NomeUtilizadorLogado;
        }

        private void CarregarComprasAbertas()
        {
            try
            {
                listBoxComprasAbertas.DataSource = null;
                listBoxComprasAbertas.DataSource = _compraController.ObterComprasAbertas();

                // Vai usar o ToString() que criaste na classe Compra
                listBoxComprasAbertas.DisplayMember = "NomeCompra";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // BOTÃO DA LISTBOX: ABRIR MODO COMPRA
        // ==========================================
        private void buttonAbrirModoCompra_Click(object sender, EventArgs e)
        {
            if (listBoxComprasAbertas.SelectedItem is Compra compraSelecionada)
            {
                // NOTA: Certifica-te que o FormPlanearCompra é o teu formulário de "ir às compras no supermercado"
                FormModoCompra form = new FormModoCompra(compraSelecionada.Id);
                form.ShowDialog();

                // Atualiza a lista quando a janela fechar (caso a compra tenha sido fechada)
                CarregarComprasAbertas();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma compra da lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // MENU DE TOPO (MenuStrip)
        // ==========================================
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void artigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Este menu no design tem o texto "Compras" mas chama-se artigosToolStripMenuItem
            // Ajusta para o Form de Gestão de Compras (ou planeamento) que desejares
            FormCriarEditarCompraPlaneada formPlaneamento = new FormCriarEditarCompraPlaneada();
            formPlaneamento.ShowDialog();
            CarregarComprasAbertas();
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

        // ==========================================
        // BOTÕES DE ACESSO RÁPIDO
        // ==========================================
        private void buttonCompra_Click(object sender, EventArgs e)
        {
            // Aqui podes abrir a Gestão de Compras (lista geral) ou criar uma nova
            // Criei a ligação que tinhas comentado
             FormPlaneamentoCompras formPlaneamentoCompras = new FormPlaneamentoCompras();
             formPlaneamentoCompras.ShowDialog();
            // CarregarComprasAbertas();
        }

        private void buttonModoCompra_Click_1(object sender, EventArgs e)
        {
            // No design, este botão tem o texto "Compra Planeada"
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
    }
}