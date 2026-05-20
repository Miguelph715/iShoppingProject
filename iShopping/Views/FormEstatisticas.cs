using iShopping.Controller;
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
    public partial class FormEstatisticas : Form
    {
        private EstatisticaController _estatisticaController;

        public FormEstatisticas()
        {
            InitializeComponent();
            _estatisticaController = new EstatisticaController();
        }

        private void FormEstatisticas_Load(object sender, EventArgs e)
        {
            // Os nomes das tabs que tinhas definido na tua imagem
            tabPage1.Text = "Estatísticas";
            tabPage2.Text = "Sugestões";

            CarregarEstatisticas();
        }

        private void CarregarEstatisticas()
        {
            // 1. Limpar as listas da Tab 1
            listBoxOrcamentosComprasMes.Items.Clear();
            listBoxPercentagemArtigos.Items.Clear();

            // 2. Preencher a ListBox da Esquerda (Mensais)
            List<string> statsMensais = _estatisticaController.ObterEstatisticasMensais();
            foreach (string stat in statsMensais)
            {
                listBoxOrcamentosComprasMes.Items.Add(stat);
            }

            // 3. Preencher a ListBox da Direita (Percentagens)
            List<string> statsPercentagens = _estatisticaController.ObterEstatisticasPercentagemArtigos();
            foreach (string stat in statsPercentagens)
            {
                listBoxPercentagemArtigos.Items.Add(stat);
            }
        }

        private void buttonGerarSugestoes_Click(object sender, EventArgs e)
        {
            // 1. Limpar a ListBox para não acumular se o utilizador clicar várias vezes
            listBoxSugestoes.Items.Clear();

            // 2. Ir buscar o Orçamento Sugerido e adicionar no topo da lista
            string sugestaoOrcamento = _estatisticaController.SugerirOrcamento();
            listBoxSugestoes.Items.Add(sugestaoOrcamento);

            // Adicionar uma linha em branco para separar visualmente
            listBoxSugestoes.Items.Add("");

            // 3. Ir buscar a Lista de Compras sugerida e adicionar por baixo
            List<string> sugestoesCompras = _estatisticaController.SugerirListaCompras();
            foreach (string item in sugestoesCompras)
            {
                listBoxSugestoes.Items.Add(item);
            }
        }
    }
}
