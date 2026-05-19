using iShopping.Controller;
using iShopping.Model;
using System;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormGestaoTiposArtigo : Form
    {
        private TipoArtigoController controller;

        public FormGestaoTiposArtigo()
        {
            InitializeComponent();
            controller = new TipoArtigoController();
        }

        private void FormGestaoTiposArtigo_Load(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            try
            {
                listBoxTiposArtigos.DataSource = null;
                listBoxTiposArtigos.DataSource = controller.ObterTodos();
                listBoxTiposArtigos.DisplayMember = "Nome";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeArtigo.Text))
            {
                MessageBox.Show("Por favor, insira um nome para o Tipo de Artigo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TipoArtigo novoTipo = new TipoArtigo
                {
                    Nome = textBoxNomeArtigo.Text.Trim()
                };

                controller.Adicionar(novoTipo);

                MessageBox.Show("Tipo de Artigo adicionado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                AtualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxTiposArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTiposArtigos.SelectedItem is TipoArtigo tipoSelecionado)
            {
                textBoxNomeArtigo.Text = tipoSelecionado.Nome;
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeArtigo.Text))
            {
                MessageBox.Show("O nome não pode estar vazio.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBoxTiposArtigos.SelectedItem is TipoArtigo tipoSelecionado)
            {
                try
                {
                    tipoSelecionado.Nome = textBoxNomeArtigo.Text.Trim();

                    controller.Atualizar(tipoSelecionado);

                    MessageBox.Show("Tipo de Artigo atualizado com sucesso!", "Sucesso",
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
                MessageBox.Show("Por favor, selecione um Tipo de Artigo na lista para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (listBoxTiposArtigos.SelectedItem is TipoArtigo tipoSelecionado)
            {
                DialogResult resposta = MessageBox.Show(
                    $"Tem a certeza que deseja eliminar o tipo '{tipoSelecionado.Nome}'?",
                    "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        bool removido = controller.Remover(tipoSelecionado.Id);

                        if (!removido)
                        {
                            MessageBox.Show(
                                "Não é possível eliminar este Tipo de Artigo porque tem Artigos associados.",
                                "Operação Não Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        MessageBox.Show("Tipo de Artigo eliminado com sucesso!", "Sucesso",
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
                MessageBox.Show("Por favor, selecione um Tipo de Artigo na lista para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxNomeArtigo.Clear();
            listBoxTiposArtigos.ClearSelected();
        }
    }
}