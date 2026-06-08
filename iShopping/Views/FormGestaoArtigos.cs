using iShopping.Controller;
using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

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
                LimparCampos();
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

                // Usar BindingSource separado para cada ComboBox evita que o WinForms
                // sincronize as seleções de ambos via CurrencyManager partilhado.
                var bsTipoArtigo = new BindingSource { DataSource = new List<TipoArtigo>(tipos) };
                comboBoxTipoArtigo.DataSource = bsTipoArtigo;
                comboBoxTipoArtigo.DisplayMember = "Nome";
                comboBoxTipoArtigo.ValueMember = "Id";

                List<TipoArtigo> tiposFiltro = new List<TipoArtigo>();
                tiposFiltro.Add(new TipoArtigo { Id = 0, Nome = "Todos" });
                tiposFiltro.AddRange(tipos);

                var bsFiltroTipo = new BindingSource { DataSource = tiposFiltro };
                comboBoxFiltroTipo.DataSource = bsFiltroTipo;
                comboBoxFiltroTipo.DisplayMember = "Nome";
                comboBoxFiltroTipo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar Tipos de Artigo: " + ex.Message);
            }
        }

        /*private void AtualizarLista()
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
        }*/

        private void AtualizarLista()
        {
            try
            {
                // Impede que a ListBox preencha automaticamente os campos durante a atualização
                listBoxArtigos.SelectedIndexChanged -= listBoxArtigos_SelectedIndexChanged;

                listBoxArtigos.DataSource = null;

                int tipoIdSelecionado = 0;

                if (comboBoxFiltroTipo.SelectedValue != null)
                {
                    int.TryParse(comboBoxFiltroTipo.SelectedValue.ToString(), out tipoIdSelecionado);
                }

                if (tipoIdSelecionado > 0)
                {
                    // Mostra apenas os artigos do tipo selecionado
                    listBoxArtigos.DataSource = artigoController.ObterPorTipo(tipoIdSelecionado);
                }
                else
                {
                    // Quando está selecionado "Todos", mostra todos os artigos
                    listBoxArtigos.DataSource = artigoController.ObterTodos();
                }

                listBoxArtigos.DisplayMember = "Nome";

                // Remove qualquer seleção automática
                listBoxArtigos.ClearSelected();
                // Garante que os campos continuam vazios
                textBoxNomeArtigo.Clear();
                comboBoxTipoArtigo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Volta a ligar o evento para quando clicares manualmente num artigo
                listBoxArtigos.SelectedIndexChanged += listBoxArtigos_SelectedIndexChanged;
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

                AtualizarLista();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*   CÓDIGO DO BUTTON EDITAR MAS TÁ A DAR ERRO A EDITAR O TIPO DE ARTIGO
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
        }*/

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!(listBoxArtigos.SelectedItem is Artigo artigoSelecionado))
            {
                MessageBox.Show("Por favor, selecione um Artigo na lista para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNomeArtigo.Text))
            {
                MessageBox.Show("O nome não pode estar vazio.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxTipoArtigo.SelectedValue == null)
            {
                MessageBox.Show("Selecione um Tipo de Artigo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = artigoSelecionado.Id;
                string nome = textBoxNomeArtigo.Text.Trim();
                int tipoArtigoId = Convert.ToInt32(comboBoxTipoArtigo.SelectedValue);

                artigoController.Atualizar(id, nome, tipoArtigoId);

                MessageBox.Show("Artigo atualizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizarLista();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Limpa a ComboBox "Tipo de Artigo"
            comboBoxTipoArtigo.SelectedIndex = -1;

            // Volta o filtro para "Todos", se existir essa opção
            comboBoxFiltroTipo.SelectedIndex = 0;

            // Remove seleção da ListBox
            listBoxArtigos.ClearSelected();

            textBoxNomeArtigo.Focus();
        }
    }
}