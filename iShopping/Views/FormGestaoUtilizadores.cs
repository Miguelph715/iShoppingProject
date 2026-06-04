using iShopping.Controller;
using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormGestaoUtilizadores : Form
    {
        private readonly UtilizadorController utilizadorController;
        private int utilizadorSelecionadoId = 0;

        public FormGestaoUtilizadores()
        {
            InitializeComponent();

            utilizadorController = new UtilizadorController();

            ConfigurarForm();
            CarregarUtilizadores();
        }

        private void ConfigurarForm()
        {
            textBoxPassword.PasswordChar = '*';

            dataGridViewUtilizadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUtilizadores.MultiSelect = false;
            dataGridViewUtilizadores.ReadOnly = true;
            dataGridViewUtilizadores.AllowUserToAddRows = false;
            dataGridViewUtilizadores.AllowUserToDeleteRows = false;
            dataGridViewUtilizadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUtilizadores.RowHeadersVisible = false;

            dataGridViewUtilizadores.CellClick += dataGridViewUtilizadores_CellClick;

            buttonGuardar.Click += buttonGuardar_Click;
            buttonEliminar.Click += buttonEliminar_Click;
            buttonLimpar.Click += buttonLimpar_Click;
        }

        private void CarregarUtilizadores()
        {
            try
            {
                List<Utilizador> utilizadores = utilizadorController.ObterTodos();

                dataGridViewUtilizadores.DataSource = null;

                dataGridViewUtilizadores.DataSource = utilizadores
                    .Select(u => new
                    {
                        u.Id,
                        u.Username
                    })
                    .ToList();

                dataGridViewUtilizadores.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar utilizadores: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                string username = textBoxUsername.Text.Trim();
                string password = textBoxPassword.Text.Trim();

                if (utilizadorSelecionadoId == 0)
                {
                    string mensagemErro;

                    bool sucesso = utilizadorController.RegistarUtilizador(
                        username,
                        password,
                        out mensagemErro
                    );

                    if (!sucesso)
                    {
                        MessageBox.Show(
                            mensagemErro,
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    MessageBox.Show(
                        "Utilizador criado com sucesso.",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    string mensagemErro;

                    bool sucesso = utilizadorController.AtualizarUtilizador(
                        utilizadorSelecionadoId,
                        username,
                        password,
                        out mensagemErro
                    );

                    if (!sucesso)
                    {
                        MessageBox.Show(
                            mensagemErro,
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    MessageBox.Show(
                        "Utilizador atualizado com sucesso.",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                CarregarUtilizadores();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao guardar utilizador: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (utilizadorSelecionadoId == 0)
            {
                MessageBox.Show(
                    "Selecione um utilizador para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Tem a certeza que pretende eliminar este utilizador?",
                "Confirmar eliminação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.No)
                return;

            try
            {
                string mensagemErro;

                bool sucesso = utilizadorController.EliminarUtilizador(
                    utilizadorSelecionadoId,
                    out mensagemErro
                );

                if (!sucesso)
                {
                    MessageBox.Show(
                        mensagemErro,
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    "Utilizador eliminado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CarregarUtilizadores();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao eliminar utilizador: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dataGridViewUtilizadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                int id = Convert.ToInt32(dataGridViewUtilizadores.Rows[e.RowIndex].Cells["Id"].Value);

                Utilizador utilizador = utilizadorController.ObterPorId(id);

                if (utilizador == null)
                {
                    MessageBox.Show(
                        "Utilizador não encontrado.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                utilizadorSelecionadoId = utilizador.Id;
                textBoxUsername.Text = utilizador.Username;
                textBoxPassword.Text = utilizador.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao selecionar utilizador: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show(
                    "Insira o username do utilizador.",
                    "Campo obrigatório",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBoxUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show(
                    "Insira a password do utilizador.",
                    "Campo obrigatório",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBoxPassword.Focus();
                return false;
            }

            return true;
        }

        private void LimparCampos()
        {
            utilizadorSelecionadoId = 0;

            textBoxUsername.Clear();
            textBoxPassword.Clear();

            dataGridViewUtilizadores.ClearSelection();

            textBoxUsername.Focus();
        }

    }
}