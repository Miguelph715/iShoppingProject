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
            // Limpa o que lá estiver antes de carregar dados novos
            listBoxOrcamentosComprasMes.Items.Clear();
            listBoxPercentagemArtigos.Items.Clear();

            // Pede as contas mensais ao Controller e preenche a ListBox da esquerda
            List<string> statsMensais = _estatisticaController.ObterEstatisticasMensais();
            foreach (string stat in statsMensais)
            {
                listBoxOrcamentosComprasMes.Items.Add(stat);
            }

            // Pede as percentagens ao Controller e preenche a ListBox da direita
            List<string> statsPercentagens = _estatisticaController.ObterEstatisticasPercentagemArtigos();
            foreach (string stat in statsPercentagens)
            {
                listBoxPercentagemArtigos.Items.Add(stat);
            }
        }
    }
}
