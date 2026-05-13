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
    public partial class FormGestaoArtigos : Form
    {
        private ArtigoController _artigoController;
        private TipoArtigoController _tipoArtigoController;

        public FormGestaoArtigos()
        {
            InitializeComponent();
            _artigoController = new ArtigoController();
            _tipoArtigoController = new TipoArtigoController(); // Precisamos deste para preencher as ComboBoxes
        }

        private void FormGestaoArtigos_Load(object sender, EventArgs e)
        {
            CarregarCombos();
            AtualizarLista();
        }

        // Preenche as duas ComboBoxes com os Tipos de Artigo que vêm da Base de Dados
        private void CarregarCombos()
        {
            List<TipoArtigo> tipos = _tipoArtigoController.ObterTodos();

            // 1. Configurar a ComboBox de criar/editar artigos
            comboBoxTipoArtigo.DataSource = new List<TipoArtigo>(tipos);
            comboBoxTipoArtigo.DisplayMember = "Nome"; // O que o utilizador vê
            comboBoxTipoArtigo.ValueMember = "Id";     // O valor guardado por trás

            // 2. Configurar a ComboBox de Filtro (Vamos adicionar uma opção "Todos" no início)
            List<TipoArtigo> tiposFiltro = new List<TipoArtigo>();
            tiposFiltro.Add(new TipoArtigo { Id = 0, Nome = "Todos" });
            tiposFiltro.AddRange(tipos);

            comboBoxFiltroTipo.DataSource = tiposFiltro;
            comboBoxFiltroTipo.DisplayMember = "Nome";
            comboBoxFiltroTipo.ValueMember = "Id";
        }

        private void AtualizarLista()
        {
            listBoxArtigos.DataSource = null;

            // Se o filtro selecionado tiver ID > 0, pesquisamos por esse tipo. Se for 0 ("Todos"), trazemos tudo.
            if (comboBoxFiltroTipo.SelectedValue != null && (int)comboBoxFiltroTipo.SelectedValue > 0)
            {
                int tipoIdSelecionado = (int)comboBoxFiltroTipo.SelectedValue;
                listBoxArtigos.DataSource = _artigoController.ObterPorTipo(tipoIdSelecionado);
            }
            else
            {
                listBoxArtigos.DataSource = _artigoController.ObterTodos();
            }

            listBoxArtigos.DisplayMember = "Nome";
        }

        // Quando o utilizador muda o filtro lá em cima
        private void cbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // O try-catch serve porque no Form Load este evento dispara antes da DataSource estar pronta
            try
            {
                AtualizarLista();
            }
            catch { }
        }

        // Quando o utilizador clica num artigo na lista
        private void listBoxArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem is Artigo artigoSelecionado)
            {
                textBoxNomeArtigo.Text = artigoSelecionado.Nome;
                comboBoxTipoArtigo.SelectedValue = artigoSelecionado.TipoArtigoId; // Seleciona automaticamente o tipo certo na combobox
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeArtigo.Text) || comboBoxTipoArtigo.SelectedValue == null)
            {
                MessageBox.Show("Preencha o nome e selecione um Tipo de Artigo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Artigo novoArtigo = new Artigo
            {
                Nome = textBoxNomeArtigo.Text.Trim(),
                TipoArtigoId = (int)comboBoxTipoArtigo.SelectedValue
            };

            _artigoController.Adicionar(novoArtigo);
            MessageBox.Show("Artigo adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimparCampos();
            AtualizarLista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem is Artigo artigoSelecionado)
            {
                artigoSelecionado.Nome = textBoxNomeArtigo.Text.Trim();
                artigoSelecionado.TipoArtigoId = (int)comboBoxTipoArtigo.SelectedValue;

                _artigoController.Atualizar(artigoSelecionado);
                MessageBox.Show("Artigo atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                AtualizarLista();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem is Artigo artigoSelecionado)
            {
                if (MessageBox.Show($"Deseja eliminar '{artigoSelecionado.Nome}'?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _artigoController.Remover(artigoSelecionado.Id);
                    LimparCampos();
                    AtualizarLista();
                }
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
