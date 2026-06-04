using iShopping.Controller;
using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormPlaneamentoCompras : Form
    {
        private CompraController _compraController;

        public FormPlaneamentoCompras()
        {
            InitializeComponent();

            _compraController = new CompraController();

            this.Load += FormPlaneamentoCompras_Load;
            comboBoxEstado.SelectedIndexChanged += comboBoxEstado_SelectedIndexChanged;
            buttonLimparCompras.Click += buttonLimparCompras_Click;
            buttonNovaCompra.Click += buttonNovaCompra_Click;
            buttonEditarCompra.Click += buttonEditarCompra_Click;
        }

        private void FormPlaneamentoCompras_Load(object sender, EventArgs e)
        {
            CarregarEstados();

            // Por defeito mostra as compras em aberto
            comboBoxEstado.SelectedItem = "Em aberto";

            CarregarCompras();
        }

        private void CarregarEstados()
        {
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxEstado.Items.Clear();
            comboBoxEstado.Items.Add("Todas");
            comboBoxEstado.Items.Add("Em aberto");
            comboBoxEstado.Items.Add("Fechadas");
        }

        private void CarregarCompras()
        {
            try
            {
                List<Compra> compras;

                string estado = comboBoxEstado.SelectedItem?.ToString();

                if (estado == "Fechadas")
                {
                    compras = _compraController.ObterTodas()
                        .Where(c => c.Fechada == true)
                        .OrderByDescending(c => c.DataCriacao)
                        .ToList();
                }
                else if (estado == "Todas")
                {
                    compras = _compraController.ObterTodas()
                        .OrderByDescending(c => c.DataCriacao)
                        .ToList();
                }
                else
                {
                    compras = _compraController.ObterComprasAbertas()
                        .OrderByDescending(c => c.DataCriacao)
                        .ToList();
                }

                listBoxCompras.DataSource = null;

                listBoxCompras.DisplayMember = "NomeCompra";
                listBoxCompras.ValueMember = "Id";
                listBoxCompras.DataSource = compras;

                listBoxCompras.ClearSelected();

                labelCompras.Text = "Compras (" + compras.Count + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar compras: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCompras();
        }

        private void buttonLimparCompras_Click(object sender, EventArgs e)
        {
            comboBoxEstado.SelectedItem = "Em aberto";
            listBoxCompras.ClearSelected();
            CarregarCompras();
        }

        private void buttonNovaCompra_Click(object sender, EventArgs e)
        {
            FormCriarEditarCompraPlaneada form = new FormCriarEditarCompraPlaneada();
            form.ShowDialog();

            CarregarCompras();
        }

        private void buttonEditarCompra_Click(object sender, EventArgs e)
        {
            if (listBoxCompras.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecione uma compra para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Compra compraSelecionada = (Compra)listBoxCompras.SelectedItem;

            Compra compraCompleta = _compraController.ObterPorId(compraSelecionada.Id);

            FormCriarEditarCompraPlaneada form = new FormCriarEditarCompraPlaneada(compraCompleta);
            form.ShowDialog();
            CarregarCompras();
        }
    }
}