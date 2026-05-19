using iShopping.Controller;
using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormGestaoArtigos : Form
    {
        private ArtigoController artigoController;
        private TipoArtigoController tipoArtigoController;

        public FormGestaoArtigos()
        {
            InitializeComponent();
            artigoController = new ArtigoController();
            tipoArtigoController = new TipoArtigoController();
        }

        private void FormGestaoArtigos_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCombos();
                AtualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarCombos()
        {
            try
            {
                List<TipoArtigo> tipos = tipoArtigoController.ObterTodos();

                comboBoxTipoArtigo.DataSource = new List<TipoArtigo>(tipos);
                comboBoxTipoArtigo.DisplayMember = "Nome";
                comboBoxTipoArtigo.ValueMember = "Id";

                List<TipoArtigo> tiposFiltro = new List<TipoArtigo>();
                tiposFiltro.Add(new TipoArtigo { Id = 0, Nome = "Todos" });
                tiposFiltro.AddRange(tipos);

                comboBoxFiltroTipo.DataSource = tiposFiltro;
                comboBoxFiltroTipo.DisplayMember = "Nome";
                comboBoxFiltroTipo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar Tipos de Artigo: " + ex.Message);
            }
        }

        private void AtualizarLista()
        {
            try
            {
                listBoxArtigos.DataSource = null;
                int tipoIdSelecionado;
                if (comboBoxFiltroTipo.SelectedValue != null &&
                    int.TryParse(comboBoxFiltroTipo.SelectedValue.ToString(), out tipoIdSelecionado) &&
                    tipoIdSelecionado > 0)
                {
                    listBoxArtigos.DataSource = artigoController.ObterPorTipo(tipoIdSelecionado);
                }

                listBoxArtigos.DisplayMember = "Nome";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AtualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem is Artigo artigoSelecionado)
            {
                textBoxNomeArtigo.Text = artigoSelecionado.Nome;
                comboBoxTipoArtigo.SelectedValue = artigoSelecionado.TipoArtigoId;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeArtigo.Text) || comboBoxTipoArtigo.SelectedValue == null)
            {
                MessageBox.Show("Preencha o nome e selecione um Tipo de Artigo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Artigo novoArtigo = new Artigo
                {
                    Nome = textBoxNomeArtigo.Text.Trim(),
                    TipoArtigoId = (int)comboBoxTipoArtigo.SelectedValue
                };

                artigoController.Adicionar(novoArtigo);

                MessageBox.Show("Artigo adicionado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                AtualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeArtigo.Text))
            {
                MessageBox.Show("O nome não pode estar vazio.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBoxArtigos.SelectedItem is Artigo artigoSelecionado)
            {
                try
                {
                    artigoSelecionado.Nome = textBoxNomeArtigo.Text.Trim();
                    artigoSelecionado.TipoArtigoId = (int)comboBoxTipoArtigo.SelectedValue;

                    artigoController.Atualizar(artigoSelecionado);

                    MessageBox.Show("Artigo atualizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    AtualizarLista();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um Artigo na lista para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem is Artigo artigoSelecionado)
            {
                DialogResult resposta = MessageBox.Show(
                    $"Tem a certeza que deseja eliminar '{artigoSelecionado.Nome}'?",
                    "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        artigoController.Remover(artigoSelecionado.Id);

                        MessageBox.Show("Artigo eliminado com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimparCampos();
                        AtualizarLista();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um Artigo na lista para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxNomeArtigo.Clear();
            if (comboBoxTipoArtigo.Items.Count > 0) comboBoxTipoArtigo.SelectedIndex = 0;
            listBoxArtigos.ClearSelected();
        }

    }
}


