using iShopping.Controller;
using iShopping.Model;
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
    public partial class FormCriarEditarCompraPlaneada: Form
    {
        private TipoArtigoController tipoArtigoController;
        private ArtigoController artigoController;

        private List<ItemCompra> itensCompra = new List<ItemCompra>();

        public FormCriarEditarCompraPlaneada()
        {
            InitializeComponent();

            tipoArtigoController = new TipoArtigoController();
            artigoController = new ArtigoController();
        }

        private void buttonAdicionarItem_Click(object sender, EventArgs e)
        {
            if (comboBoxTipoArtigo.SelectedItem == null)
            {
                MessageBox.Show("Selecione o tipo de artigo.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxArtigo.SelectedItem == null)
            {
                MessageBox.Show("Selecione o artigo.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericQuantidadePrevista.Value <= 0)
            {
                MessageBox.Show("A quantidade deve ser superior a 0.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Artigo artigoSelecionado = (Artigo)comboBoxArtigo.SelectedItem;
            int quantidade = (int)numericQuantidadePrevista.Value;

            bool artigoJaExiste = itensCompra.Any(i => i.ArtigoId == artigoSelecionado.Id);

            if (artigoJaExiste)
            {
                MessageBox.Show("Este artigo já foi adicionado à compra.", "Artigo repetido", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ItemCompra novoItem = new ItemCompra
            {
                ArtigoId = artigoSelecionado.Id,
                Artigo = artigoSelecionado,
                ArtigoPrevisto = true,
                QuantidadePrevista = quantidade,
                QuantidadeAdquirida = 0,
                PrecoUnitario = 0,
                Observacoes = "",
                CriadoPorId = UtilizadorController.UtilizadorLogadoId.Value,
                DataCriacao = DateTime.Now
            };

            itensCompra.Add(novoItem);

            AtualizarListaItensCompra();
            LimparCamposItem();
        }

        private void AtualizarListaItensCompra()
        {
            listBoxItensCompra.DataSource = null;
            listBoxItensCompra.DataSource = itensCompra;
        }

        private void LimparCamposItem()
        {
            comboBoxTipoArtigo.SelectedIndex = -1;
            comboBoxArtigo.DataSource = null;
            numericQuantidadePrevista.Value = 0;
        }
    }
}

