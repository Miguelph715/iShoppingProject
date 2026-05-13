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
    public partial class FormGestaoTiposArtigo: Form
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

        // Método auxiliar para recarregar a ListBox sempre que há alterações
        private void AtualizarLista()
        {
            // Pede ao controller todos os tipos de artigo
            listBoxTiposArtigos.DataSource = null; // Limpa a fonte de dados atual
            listBoxTiposArtigos.DataSource = controller.ObterTodos();

            // Diz à ListBox para mostrar a propriedade "Nome" do objeto
            listBoxTiposArtigos.DisplayMember = "Nome";
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeArtigo.Text))
            {
                MessageBox.Show("Por favor, insira um nome para o Tipo de Artigo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Criar um novo objeto TipoArtigo
            TipoArtigo novoTipo = new TipoArtigo
            {
                Nome = textBoxNomeArtigo.Text.Trim()
            };

            // Enviar para o controller guardar
            controller.Adicionar(novoTipo);

            MessageBox.Show("Tipo de Artigo adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);

            LimparCampos();
            AtualizarLista();
        }

        private void listBoxTiposArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se houver algum item selecionado, passa o nome para a TextBox
            if (listBoxTiposArtigos.SelectedItem is TipoArtigo tipoSelecionado)
            {
                textBoxNomeArtigo.Text = tipoSelecionado.Nome;
            }

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeArtigo.Text))
            {
                MessageBox.Show("O nome não pode estar vazio.", "Aviso", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            if (listBoxTiposArtigos.SelectedItem is TipoArtigo tipoSelecionado)
            {
                // Atualiza o nome do objeto selecionado
                tipoSelecionado.Nome = textBoxNomeArtigo.Text.Trim();

                // Pede ao controller para atualizar na BD
                controller.Atualizar(tipoSelecionado);

                MessageBox.Show("Tipo de Artigo atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                LimparCampos();
                AtualizarLista();
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
                // Confirmar antes de eliminar
                DialogResult resposta = MessageBox.Show($"Tem a certeza que deseja eliminar o tipo " +
                    $"'{tipoSelecionado.Nome}'?", "Confirmar Eliminação", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    // Pede ao controller para remover usando o Id
                    controller.Remover(tipoSelecionado.Id);

                    LimparCampos();
                    AtualizarLista();
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

        // Método auxiliar para limpar a TextBox e tirar a seleção da lista
        private void LimparCampos()
        {
            textBoxNomeArtigo.Clear();
            listBoxTiposArtigos.ClearSelected(); // Tira a seleção da ListBox
        }
    }
}
