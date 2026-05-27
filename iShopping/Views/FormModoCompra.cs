using iShopping.Controller;
using iShopping.Model;
using System;
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

        public FormModoCompra(int compraId)
        {
            InitializeComponent();

            compraIdAtual = compraId;
            compraController = new CompraController();
            tipoArtigoController = new TipoArtigoController();
            artigoController = new ArtigoController();

            this.Load += FormModoCompra_Load;
            this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            this.listBoxItensCompra.SelectedIndexChanged += listBoxItensCompra_SelectedIndexChanged;
            this.buttonMarcarAdquirido.Click += buttonMarcarAdquirido_Click;
            this.buttonNaoPrevisto.Click += buttonNaoPrevisto_Click;
            this.buttonFecharCompra.Click += buttonFecharCompra_Click;
            this.buttonVoltar.Click += buttonVoltar_Click;
            this.buttonLimpar.Click += buttonLimpar_Click;
        }

        // ==========================================
        // LOAD DO FORMULÁRIO
        // ==========================================
        private void FormModoCompra_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarTiposArtigo();
                CarregarDadosCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTiposArtigo()
        {
            try
            {
                comboBox1.DataSource = tipoArtigoController.ObterTodos();
                comboBox1.DisplayMember = "Nome";
                comboBox1.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar Tipos de Artigo: " + ex.Message);
            }
        }

        private void CarregarDadosCompra()
        {
            try
            {
                compraAtual = compraController.ObterPorId(compraIdAtual);

                // Verifica se a compra existe na BD
                if (compraAtual == null)
                {
                    MessageBox.Show("Compra não encontrada na base de dados.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Verifica se a compra já está fechada
                if (compraAtual.Fechada)
                {
                    MessageBox.Show("Esta compra já está fechada e não pode ser alterada.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                labelCompra.Text = "Compra: " + compraAtual.NomeCompra;

                listBoxItensCompra.DataSource = null;
                listBoxItensCompra.DataSource = compraAtual.ItensCompra.ToList();
                listBoxItensCompra.DisplayMember = "NomeArtigo"; // ajusta conforme o teu modelo

                AtualizarOrcamento();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar dados da compra: " + ex.Message);
            }
        }

        private void AtualizarOrcamento()
        {
            try
            {
                decimal disponivel = compraController.ObterOrcamentoDisponivel(
                    compraAtual.DataCriacao.Month,
                    compraAtual.DataCriacao.Year);

                labelOrcamento.Text = "Orçamento Disponível: " + disponivel.ToString("C");

                // Regra 17: Alerta BEM VISÍVEL se orçamento ultrapassado
                if (disponivel < 0)
                {
                    labelOrcamento.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show("ATENÇÃO! O orçamento mensal foi ultrapassado!",
                        "Alerta de Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    labelOrcamento.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar orçamento: " + ex.Message);
            }
        }

        // ==========================================
        // EVENTOS DE INTERAÇÃO
        // ==========================================

        // Regra 11: Filtrar artigos pelo tipo selecionado
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedValue is int tipoId)
                {
                    comboBox2.DataSource = artigoController.ObterPorTipo(tipoId);
                    comboBox2.DisplayMember = "Nome";
                    comboBox2.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Preenche os campos ao selecionar um item da lista
        private void listBoxItensCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItensCompra.SelectedItem is ItemCompra item)
            {
                try
                {
                    comboBox1.SelectedValue = item.Artigo.TipoArtigoId;
                    comboBox2.SelectedValue = item.ArtigoId;
                    numericUpDown1.Value = item.QuantidadeAdquirida;
                    numericUpDown2.Value = item.PrecoUnitario;
                    textBox1.Text = item.Observacoes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // BOTÕES DE AÇÃO
        // ==========================================

        // Regra 13: Marcar Item Previsto como Adquirido
        private void buttonMarcarAdquirido_Click(object sender, EventArgs e)
        {
            if (listBoxItensCompra.SelectedItem is ItemCompra itemSelecionado)
            {
                // Validações básicas
                if (numericUpDown1.Value <= 0)
                {
                    MessageBox.Show("A quantidade deve ser superior a 0.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numericUpDown2.Value <= 0)
                {
                    MessageBox.Show("O preço unitário deve ser superior a 0.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (var db = new iShoppingContext())
                    {
                        var itemDb = db.ItensCompra.Find(itemSelecionado.Id);
                        if (itemDb != null)
                        {
                            itemDb.QuantidadeAdquirida = (int)numericUpDown1.Value;
                            itemDb.PrecoUnitario = numericUpDown2.Value;
                            itemDb.Observacoes = textBox1.Text;
                            db.SaveChanges();
                        }
                    }

                    MessageBox.Show("Item atualizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarDadosCompra();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar item: " + ex.Message, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item da lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Regras 14 e 15: Adicionar Artigo Não Previsto
        private void buttonNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um artigo.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("A quantidade deve ser superior a 0.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDown2.Value <= 0)
            {
                MessageBox.Show("O preço unitário deve ser superior a 0.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox2.SelectedItem is Artigo artigoSelecionado)
            {
                try
                {
                    using (var db = new iShoppingContext())
                    {
                        var novoItem = new ItemCompra
                        {
                            CompraId = compraIdAtual,
                            ArtigoId = artigoSelecionado.Id,
                            QuantidadePrevista = 0,
                            QuantidadeAdquirida = (int)numericUpDown1.Value,
                            PrecoUnitario = numericUpDown2.Value,
                            ArtigoPrevisto = false,
                            Observacoes = textBox1.Text
                        };
                        db.ItensCompra.Add(novoItem);
                        db.SaveChanges();
                    }

                    MessageBox.Show("Artigo não previsto adicionado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarDadosCompra();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar item não previsto: " + ex.Message, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Regra 18: Fechar a Compra
        private void buttonFecharCompra_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = MessageBox.Show(
                    "Tem a certeza que deseja fechar esta compra? Não poderá alterá-la depois.",
                    "Confirmar Fecho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    if (UtilizadorController.UtilizadorLogadoId == null)
                    {
                        MessageBox.Show("Não existe utilizador com sessão iniciada.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    compraController.FecharCompra(compraIdAtual,
                        UtilizadorController.UtilizadorLogadoId.Value);

                    MessageBox.Show("Compra fechada com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparCampos()
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            textBox1.Clear();
            listBoxItensCompra.ClearSelected();
        }
    }
}