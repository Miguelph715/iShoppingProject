using iShopping.Controller;
using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormModoCompra : Form
    {
        private int compraIdAtual;
        private CompraController compraController;
        private TipoArtigoController tipoArtigoController;
        private ArtigoController artigoController;
        private Compra compraAtual;

        private bool aCarregar;
        private bool avisoOrcamentoMostrado;

        public FormModoCompra()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        public FormModoCompra(int compraId) : this()
        {
            compraIdAtual = compraId;
        }

        private void InicializarFormulario()
        {
            compraController = new CompraController();
            tipoArtigoController = new TipoArtigoController();
            artigoController = new ArtigoController();

            ConfigurarControlos();
            LigarEventosUmaVez();
        }

        private void ConfigurarControlos()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 100000;

            numericUpDown2.Minimum = 0;
            numericUpDown2.Maximum = 1000000;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Increment = 0.10M;

            labelCompra.Text = "Compra:";
            labelOrcamento.Text = "Orçamento Disponível:";

            lblNomeCompra.Text = "";
            lblOrcamentoValor.Text = "";
            lblQuantidadePrevista.Text = "Quantidade prevista: -";
        }

        private void LigarEventosUmaVez()
        {
            this.Load -= FormModoCompra_Load;

            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;

            listBoxItensCompra.SelectedIndexChanged -= listBoxItensCompra_SelectedIndexChanged;
            listBoxItensCompra.Format -= listBoxItensCompra_Format;

            buttonMarcarAdquirido.Click -= buttonMarcarAdquirido_Click;
            buttonNaoPrevisto.Click -= buttonNaoPrevisto_Click;
            buttonFecharCompra.Click -= buttonFecharCompra_Click;
            buttonVoltar.Click -= buttonVoltar_Click;
            buttonLimpar.Click -= buttonLimpar_Click;

            this.Load += FormModoCompra_Load;

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            listBoxItensCompra.SelectedIndexChanged += listBoxItensCompra_SelectedIndexChanged;
            listBoxItensCompra.Format += listBoxItensCompra_Format;

            buttonMarcarAdquirido.Click += buttonMarcarAdquirido_Click;
            buttonNaoPrevisto.Click += buttonNaoPrevisto_Click;
            buttonFecharCompra.Click += buttonFecharCompra_Click;
            buttonVoltar.Click += buttonVoltar_Click;
            buttonLimpar.Click += buttonLimpar_Click;
        }

        private void FormModoCompra_Load(object sender, EventArgs e)
        {
            try
            {
                if (compraIdAtual <= 0)
                {
                    MessageBox.Show(
                        "É necessário abrir o modo compra através de uma compra selecionada.",
                        "Compra não selecionada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    Close();
                    return;
                }

                CarregarTiposArtigo();
                CarregarDadosCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao abrir o modo compra: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CarregarTiposArtigo()
        {
            try
            {
                aCarregar = true;

                comboBox1.DataSource = null;
                comboBox1.DisplayMember = "Nome";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = tipoArtigoController.ObterTodos();
                comboBox1.SelectedIndex = -1;

                comboBox2.DataSource = null;
                comboBox2.DisplayMember = "Nome";
                comboBox2.ValueMember = "Id";
                comboBox2.SelectedIndex = -1;
            }
            finally
            {
                aCarregar = false;
            }
        }

        private void CarregarArtigosPorTipo(int tipoArtigoId)
        {
            try
            {
                aCarregar = true;

                comboBox2.DataSource = null;
                comboBox2.DisplayMember = "Nome";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource = artigoController.ObterPorTipo(tipoArtigoId);
                comboBox2.SelectedIndex = -1;
            }
            finally
            {
                aCarregar = false;
            }
        }

        private void CarregarDadosCompra()
        {
            compraAtual = compraController.ObterPorId(compraIdAtual);

            if (compraAtual == null)
            {
                MessageBox.Show(
                    "Compra não encontrada na base de dados.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
                return;
            }

            if (compraAtual.Fechada)
            {
                MessageBox.Show(
                    "Esta compra já está fechada e não pode ser alterada.",
                    "Compra fechada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Close();
                return;
            }

            lblNomeCompra.Text = compraAtual.NomeCompra;

            var itens = compraAtual.ItensCompra == null
                ? new List<ItemCompra>()
                : compraAtual.ItensCompra
                    .OrderBy(i => i.ArtigoPrevisto ? 0 : 1)
                    .ThenBy(i => i.Artigo != null ? i.Artigo.Nome : "")
                    .ToList();

            aCarregar = true;

            listBoxItensCompra.DataSource = null;
            listBoxItensCompra.DataSource = itens;
            listBoxItensCompra.ClearSelected();

            aCarregar = false;

            lblQuantidadePrevista.Text = "Quantidade prevista: -";

            AtualizarOrcamento();
            LimparCampos(false);
        }

        private void AtualizarOrcamento()
        {
            if (compraAtual == null)
            {
                lblOrcamentoValor.Text = "-";
                return;
            }

            DateTime dataReferencia = compraAtual.DataCriacao == DateTime.MinValue
                ? DateTime.Now
                : compraAtual.DataCriacao;

            decimal disponivel = compraController.ObterOrcamentoDisponivel(
                dataReferencia.Month,
                dataReferencia.Year
            );

            lblOrcamentoValor.Text = disponivel.ToString("C2");

            if (disponivel < 0)
            {
                lblOrcamentoValor.ForeColor = Color.Red;

                if (!avisoOrcamentoMostrado)
                {
                    avisoOrcamentoMostrado = true;

                    MessageBox.Show(
                        "Atenção: o orçamento mensal foi ultrapassado.",
                        "Orçamento ultrapassado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            else
            {
                lblOrcamentoValor.ForeColor = Color.Green;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aCarregar)
                return;

            try
            {
                if (comboBox1.SelectedValue is int tipoArtigoId)
                {
                    CarregarArtigosPorTipo(tipoArtigoId);
                }
                else
                {
                    comboBox2.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar artigos do tipo selecionado: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void listBoxItensCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aCarregar)
                return;

            if (listBoxItensCompra.SelectedItem is ItemCompra item)
            {
                PreencherCamposComItem(item);
            }
        }

        private void listBoxItensCompra_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ItemCompra item)
            {
                e.Value = ObterTextoItemCompra(item);
            }
        }

        private string ObterTextoItemCompra(ItemCompra item)
        {
            string nomeArtigo = item.Artigo != null
                ? item.Artigo.Nome
                : "Artigo #" + item.ArtigoId;

            string tipo = item.ArtigoPrevisto
                ? "Previsto"
                : "Não previsto";

            return nomeArtigo
                + " | " + tipo
                + " | Prev.: " + item.QuantidadePrevista
                + " | Adq.: " + item.QuantidadeAdquirida
                + " | " + item.PrecoUnitario.ToString("C2");
        }

        private void PreencherCamposComItem(ItemCompra item)
        {
            try
            {
                if (item.Artigo == null)
                {
                    MessageBox.Show(
                        "Este item não tem artigo associado. Verifica os dados na base de dados.",
                        "Dados incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                int tipoArtigoId = item.Artigo.TipoArtigoId;

                aCarregar = true;
                comboBox1.SelectedValue = tipoArtigoId;
                aCarregar = false;

                CarregarArtigosPorTipo(tipoArtigoId);

                aCarregar = true;

                comboBox2.SelectedValue = item.ArtigoId;
                numericUpDown1.Value = ValorDentroDoIntervalo(numericUpDown1, item.QuantidadeAdquirida);
                numericUpDown2.Value = ValorDentroDoIntervalo(numericUpDown2, item.PrecoUnitario);
                textBox1.Text = item.Observacoes ?? "";
                lblQuantidadePrevista.Text = "Quantidade prevista: " + item.QuantidadePrevista;

                aCarregar = false;
            }
            catch (Exception ex)
            {
                aCarregar = false;

                MessageBox.Show(
                    "Erro ao selecionar o item: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private decimal ValorDentroDoIntervalo(NumericUpDown controlo, decimal valor)
        {
            if (valor < controlo.Minimum)
                return controlo.Minimum;

            if (valor > controlo.Maximum)
                return controlo.Maximum;

            return valor;
        }

        private void buttonMarcarAdquirido_Click(object sender, EventArgs e)
        {
            if (!(listBoxItensCompra.SelectedItem is ItemCompra itemSelecionado))
            {
                MessageBox.Show(
                    "Selecione primeiro um item da lista.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!ValidarQuantidadeEPreco())
                return;

            try
            {
                using (var db = new iShoppingContext())
                {
                    var itemDb = db.ItensCompra.Find(itemSelecionado.Id);

                    if (itemDb == null)
                        throw new Exception("O item selecionado já não existe na base de dados.");

                    var compraDb = db.Compras.Find(compraIdAtual);

                    if (compraDb == null)
                        throw new Exception("Compra não encontrada.");

                    if (compraDb.Fechada)
                        throw new Exception("Esta compra já está fechada e não pode ser alterada.");

                    itemDb.QuantidadeAdquirida = (int)numericUpDown1.Value;
                    itemDb.PrecoUnitario = numericUpDown2.Value;
                    itemDb.Observacoes = textBox1.Text.Trim();
                    itemDb.DataAlteracao = DateTime.Now;

                    if (UtilizadorController.UtilizadorLogadoId != null)
                    {
                        itemDb.AlteradoPorId = UtilizadorController.UtilizadorLogadoId.Value;
                    }

                    db.SaveChanges();
                }

                MessageBox.Show(
                    "Item atualizado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CarregarDadosCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao atualizar item: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buttonNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (!(comboBox2.SelectedValue is int artigoId))
            {
                MessageBox.Show(
                    "Selecione primeiro o tipo de artigo e o artigo.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (UtilizadorController.UtilizadorLogadoId == null)
            {
                MessageBox.Show(
                    "Não existe utilizador com sessão iniciada.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (!ValidarQuantidadeEPreco())
                return;

            try
            {
                using (var db = new iShoppingContext())
                {
                    var compraDb = db.Compras.Find(compraIdAtual);

                    if (compraDb == null)
                        throw new Exception("Compra não encontrada.");

                    if (compraDb.Fechada)
                        throw new Exception("Esta compra já está fechada e não pode ser alterada.");

                    bool artigoJaExiste = db.ItensCompra.Any(i =>
                        i.CompraId == compraIdAtual &&
                        i.ArtigoId == artigoId
                    );

                    if (artigoJaExiste)
                    {
                        MessageBox.Show(
                            "Este artigo já existe nesta compra. Selecione-o na lista e atualize a quantidade/preço.",
                            "Artigo já existente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        return;
                    }

                    var novoItem = new ItemCompra
                    {
                        CompraId = compraIdAtual,
                        ArtigoId = artigoId,
                        ArtigoPrevisto = false,
                        QuantidadePrevista = 0,
                        QuantidadeAdquirida = (int)numericUpDown1.Value,
                        PrecoUnitario = numericUpDown2.Value,
                        Observacoes = textBox1.Text.Trim(),
                        CriadoPorId = UtilizadorController.UtilizadorLogadoId.Value,
                        DataCriacao = DateTime.Now
                    };

                    db.ItensCompra.Add(novoItem);
                    db.SaveChanges();
                }

                MessageBox.Show(
                    "Artigo não previsto adicionado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CarregarDadosCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao adicionar artigo não previsto: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidarQuantidadeEPreco()
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show(
                    "A quantidade adquirida deve ser superior a 0.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (numericUpDown2.Value <= 0)
            {
                MessageBox.Show(
                    "O preço unitário deve ser superior a 0.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }

        private void buttonFecharCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (UtilizadorController.UtilizadorLogadoId == null)
                {
                    MessageBox.Show(
                        "Não existe utilizador com sessão iniciada.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                DialogResult resposta = MessageBox.Show(
                    "Tem a certeza que deseja fechar esta compra? Depois de fechada, a compra não poderá ser alterada.",
                    "Confirmar fecho da compra",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resposta != DialogResult.Yes)
                    return;

                compraController.FecharCompra(compraIdAtual, UtilizadorController.UtilizadorLogadoId.Value);

                MessageBox.Show(
                    "Compra fechada com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao fechar compra: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos(true);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimparCampos(bool limparSelecao)
        {
            aCarregar = true;

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            textBox1.Clear();
            lblQuantidadePrevista.Text = "Quantidade prevista: -";

            if (limparSelecao)
            {
                listBoxItensCompra.ClearSelected();
                comboBox1.SelectedIndex = -1;
                comboBox2.DataSource = null;
            }

            aCarregar = false;
        }
    }
}