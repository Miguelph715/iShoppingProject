using iShopping.Controller;
using iShopping.Model;
using iShopping.Views;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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

            this.Load += FormPrincipal_Load;
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
                var comprasAbertas = _compraController.ObterComprasAbertas();

                listBoxComprasAbertas.DataSource = null;

                listBoxComprasAbertas.DisplayMember = "NomeCompra";
                listBoxComprasAbertas.ValueMember = "Id";
                listBoxComprasAbertas.DataSource = comprasAbertas;

                listBoxComprasAbertas.ClearSelected();

                labelComprasAbertas.Text = "Compras em Aberto (" + comprasAbertas.Count + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar compras em aberto: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
             CarregarComprasAbertas();
        }

        private void buttonPlaneamentoCompras_Click(object sender, EventArgs e)
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

        private void utilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestaoUtilizadores formGestaoUtilizadores = new FormGestaoUtilizadores();
            formGestaoUtilizadores.ShowDialog();
        }

        // ==========================================
        // EXPORTAR COMPRAS FECHADAS PARA CSV
        // ==========================================
        private void buttonExportarComprasFechadasCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UtilizadorController.UtilizadorLogadoId.HasValue)
                {
                    MessageBox.Show(
                        "Não existe nenhum utilizador logado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                int utilizadorId = UtilizadorController.UtilizadorLogadoId.Value;

                var comprasFechadas = _compraController.ObterComprasFechadasPorUtilizador(utilizadorId);

                if (comprasFechadas == null || comprasFechadas.Count == 0)
                {
                    MessageBox.Show(
                        "Não existem compras fechadas para exportar.",
                        "Informação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Ficheiro CSV (*.csv)|*.csv";
                    saveFileDialog.Title = "Exportar Compras Fechadas para CSV";
                    saveFileDialog.FileName = "compras_fechadas_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";

                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    StringBuilder csv = new StringBuilder();

                    csv.AppendLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                    foreach (var compra in comprasFechadas)
                    {
                        if (compra.ItensCompra == null || compra.ItensCompra.Count == 0)
                        {
                            csv.AppendLine(CriarLinhaCsv(
                                compra.NomeCompra,
                                compra.DataCriacao.ToString("dd/MM/yyyy HH:mm"),
                                compra.DataFechada.HasValue ? compra.DataFechada.Value.ToString("dd/MM/yyyy HH:mm") : "",
                                "",
                                "Não",
                                "Não",
                                "0",
                                "0",
                                "0,00"
                            ));

                            continue;
                        }

                        foreach (var item in compra.ItensCompra)
                        {
                            string nomeArtigo = "";

                            if (item.Artigo != null)
                            {
                                nomeArtigo = item.Artigo.Nome;
                            }

                            csv.AppendLine(CriarLinhaCsv(
                                compra.NomeCompra,
                                compra.DataCriacao.ToString("dd/MM/yyyy HH:mm"),
                                compra.DataFechada.HasValue ? compra.DataFechada.Value.ToString("dd/MM/yyyy HH:mm") : "",
                                nomeArtigo,
                                item.ArtigoPrevisto ? "Sim" : "Não",
                                item.ArtigoPrevisto ? "Não" : "Sim",
                                item.QuantidadePrevista.ToString(),
                                item.QuantidadeAdquirida.ToString(),
                                item.PrecoUnitario.ToString("0.00", CultureInfo.GetCultureInfo("pt-PT"))
                            ));
                        }
                    }

                    File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);

                    MessageBox.Show(
                        "Compras fechadas exportadas com sucesso.",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao exportar compras fechadas: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string CriarLinhaCsv(params string[] campos)
        {
            return string.Join(";", campos.Select(PrepararCampoCsv));
        }

        private string PrepararCampoCsv(string valor)
        {
            if (valor == null)
            {
                return "";
            }

            valor = valor.Replace("\"", "\"\"");

            if (valor.Contains(";") || valor.Contains("\"") || valor.Contains("\n") || valor.Contains("\r"))
            {
                return "\"" + valor + "\"";
            }

            return valor;
        }
    }
}