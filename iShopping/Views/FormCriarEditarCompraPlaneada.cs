using iShopping.Controller;
using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormCriarEditarCompraPlaneada : Form
    {
        private TipoArtigoController tipoArtigoController;
        private ArtigoController artigoController;
        private CompraController compraController;

        private List<ItemCompra> itensCompra = new List<ItemCompra>();

        private Compra compraAtual;

        // ==========================================
        // CONSTRUTORES
        // ==========================================

        public FormCriarEditarCompraPlaneada()
        {
            InitializeComponent();
            InicializarControladores();
            compraAtual = new Compra();
        }

        public FormCriarEditarCompraPlaneada(Compra compraParaEditar)
        {
            InitializeComponent();
            InicializarControladores();
            compraAtual = compraParaEditar;
        }

        private void InicializarControladores()
        {
            tipoArtigoController = new TipoArtigoController();
            artigoController = new ArtigoController();
            compraController = new CompraController();
        }

        // ==========================================
        // EVENTOS DO FORMULÁRIO
        // ==========================================

        private void FormCriarEditarCompraPlaneada_Load(object sender, EventArgs e)
        {
            CarregarTiposArtigo();

            // Se for modo Edição, recarregar a compra da BD com Include dos Artigos
            if (compraAtual.Id > 0)
            {
                // CORREÇÃO: Recarrega da BD para garantir que Artigo está preenchido
                Compra compraCompleta = compraController.ObterPorId(compraAtual.Id);

                if (compraCompleta != null)
                {
                    compraAtual = compraCompleta;
                    textBoxNomeCompra.Text = compraAtual.NomeCompra;

                    if (compraAtual.ItensCompra != null)
                    {
                        itensCompra = compraAtual.ItensCompra.ToList();
                        AtualizarListaItensCompra();
                    }

                    if (compraAtual.Fechada)
                    {
                        DesativarModoEdicao();
                        MessageBox.Show("Esta compra já está fechada. Apenas pode visualizar os dados.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível carregar os dados da compra.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void comboBoxTipoArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarListaArtigos();
        }

        private void buttonAdicionarItem_Click(object sender, EventArgs e)
        {
            if (comboBoxArtigo.SelectedItem == null || numericQuantidadePrevista.Value <= 0)
            {
                MessageBox.Show("Selecione um artigo válido e indique uma quantidade superior a zero.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Artigo artigoSelecionado = (Artigo)comboBoxArtigo.SelectedItem;
            int quantidade = (int)numericQuantidadePrevista.Value;

            if (itensCompra.Any(i => i.ArtigoId == artigoSelecionado.Id))
            {
                MessageBox.Show("Este artigo já foi adicionado à compra.",
                    "Artigo repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ItemCompra novoItem = new ItemCompra
            {
                ArtigoId = artigoSelecionado.Id,
                Artigo = artigoSelecionado, // IMPORTANTE: Guarda também a referência do objeto
                NomeArtigoParaMostrar = artigoSelecionado.Nome,
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

        private void buttonRemoverItem_Click(object sender, EventArgs e)
        {
            if (listBoxItensCompra.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item da compra para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ItemCompra itemSelecionado = (ItemCompra)listBoxItensCompra.SelectedItem;

            DialogResult resposta = MessageBox.Show(
                "Tem a certeza que pretende eliminar este item da compra?",
                "Confirmar eliminação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                itensCompra.Remove(itemSelecionado);
                AtualizarListaItensCompra();
                LimparCamposItem();

                MessageBox.Show("Item eliminado com sucesso.",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEditarItem_Click(object sender, EventArgs e)
        {
            if (listBoxItensCompra.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item da lista para editar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericQuantidadePrevista.Value <= 0)
            {
                MessageBox.Show("Indique uma quantidade superior a zero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ItemCompra itemSelecionado = (ItemCompra)listBoxItensCompra.SelectedItem;
            itemSelecionado.QuantidadePrevista = (int)numericQuantidadePrevista.Value;
            AtualizarListaItensCompra();
            LimparCamposItem();
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            LimparCamposItem();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNomeCompra.Text))
                {
                    MessageBox.Show("Dê um nome à sua compra.", "Aviso");
                    return;
                }

                compraAtual.NomeCompra = textBoxNomeCompra.Text;
                compraAtual.ItensCompra = itensCompra;

                if (compraAtual.Id == 0)
                {
                    compraAtual.DataCriacao = DateTime.Now;
                    compraAtual.Fechada = false;
                    compraAtual.CriadoPorId = UtilizadorController.UtilizadorLogadoId.Value;

                    compraController.Adicionar(compraAtual);
                    MessageBox.Show("Compra planeada com sucesso!");
                }
                else
                {
                    compraAtual.DataAlteracao = DateTime.Now;
                    compraAtual.AlteradoPorId = UtilizadorController.UtilizadorLogadoId.Value;

                    compraController.Atualizar(compraAtual);
                    MessageBox.Show("Compra atualizada com sucesso!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao guardar: " + ex.Message, "Erro");
            }
        }

        // ==========================================
        // FUNÇÕES DE APOIO
        // ==========================================

        private void CarregarTiposArtigo()
        {
            comboBoxTipoArtigo.DataSource = tipoArtigoController.ObterTodos();
            comboBoxTipoArtigo.DisplayMember = "Nome";
            comboBoxTipoArtigo.ValueMember = "Id";
            comboBoxTipoArtigo.SelectedIndex = -1;
        }

        private void AtualizarListaArtigos()
        {
            if (comboBoxTipoArtigo.SelectedItem != null)
            {
                TipoArtigo tipoSelecionado = (TipoArtigo)comboBoxTipoArtigo.SelectedItem;

                var artigosFiltrados = artigoController.ObterPorTipo(tipoSelecionado.Id);

                comboBoxArtigo.DataSource = null;
                comboBoxArtigo.DataSource = artigosFiltrados;
                comboBoxArtigo.DisplayMember = "Nome";
                comboBoxArtigo.ValueMember = "Id";
                comboBoxArtigo.SelectedIndex = -1;
            }
            else
            {
                comboBoxArtigo.DataSource = null;
            }
        }

        private void AtualizarListaItensCompra()
        {
            listBoxItensCompra.DataSource = null;
            listBoxItensCompra.DataSource = itensCompra;
        }

        private void LimparCamposItem()
        {
            comboBoxArtigo.DataSource = null;
            comboBoxTipoArtigo.SelectedIndex = -1;
            numericQuantidadePrevista.Value = 0;
        }

        private void DesativarModoEdicao()
        {
            textBoxNomeCompra.Enabled = false;
            comboBoxTipoArtigo.Enabled = false;
            comboBoxArtigo.Enabled = false;
            numericQuantidadePrevista.Enabled = false;
            buttonAdicionarItem.Enabled = false;
            buttonEditarItem.Enabled = false;
            buttonGuardarCompra.Enabled = false;
        }
    }
}
