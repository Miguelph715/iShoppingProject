using iShopping.Controller;
using iShopping.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormPlanearCompra : Form
    {
        // Variáveis globais do formulário
        private int compraIdAtual;
        private CompraController compraController;
        private TipoArtigoController tipoArtigoController;
        private ArtigoController artigoController;
        private Compra compraAtual;

        // 1. ALTERAÇÃO IMPORTANTE: O construtor tem de receber o ID da compra selecionada no Planeamento!
        public FormPlanearCompra(int compraId)
        {
            InitializeComponent();

            compraIdAtual = compraId;
            compraController = new CompraController();
            tipoArtigoController = new TipoArtigoController();
            artigoController = new ArtigoController();

            // Ligação automática dos eventos (assim não precisas de ir ao menu das Propriedades/Raio amarelo)
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
            comboBox1.DataSource = tipoArtigoController.ObterTodos();
            comboBox1.DisplayMember = "Nome";
            comboBox1.ValueMember = "Id";
        }

        private void CarregarDadosCompra()
        {
            compraAtual = compraController.ObterPorId(compraIdAtual);
            labelCompra.Text = "Compra: " + compraAtual.NomeCompra;

            // Atualizar a lista de itens
            listBoxItensCompra.DataSource = null;
            listBoxItensCompra.DataSource = compraAtual.ItensCompra.ToList();

            AtualizarOrcamento();
        }

        private void AtualizarOrcamento()
        {
            // Regra 16: Mostrar orçamento disponível a diminuir dinamicamente
            decimal disponivel = compraController.ObterOrcamentoDisponivel(compraAtual.DataCriacao.Month, compraAtual.DataCriacao.Year);
            labelOrcamento.Text = "Orçamento Disponível: " + disponivel.ToString("C");

            // Regra 17: Alerta BEM VISÍVEL se for ultrapassado
            if (disponivel < 0)
            {
                MessageBox.Show("ATENÇÃO! O Orçamento mensal definido foi ultrapassado!", "Alerta de Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // EVENTOS DE INTERAÇÃO (Regra 11)
        // ==========================================

        // Regra 11: Na escolha do Artigo, deve primeiro escolher o Tipo de forma a filtrar a caixa dos Artigos
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int tipoId)
            {
                comboBox2.DataSource = artigoController.ObterPorTipo(tipoId);
                comboBox2.DisplayMember = "Nome";
                comboBox2.ValueMember = "Id";
            }
        }

        // Quando o utilizador clica num item da lista para o analisar
        private void listBoxItensCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItensCompra.SelectedItem is ItemCompra item)
            {
                comboBox1.SelectedValue = item.Artigo.TipoArtigoId;
                comboBox2.SelectedValue = item.ArtigoId;

                // Preenche as caixas com os valores para facilitar o registo
                numericUpDown1.Value = item.QuantidadeAdquirida;
                numericUpDown2.Value = item.PrecoUnitario;
                textBox1.Text = item.Observacoes;
            }
        }

        // ==========================================
        // BOTÕES DE AÇÃO (Regras 13, 14, 15 e 18)
        // ==========================================

        // Regra 13: Marcar Item Previsto como Adquirido (indicando quantidade e preço)
        private void buttonMarcarAdquirido_Click(object sender, EventArgs e)
        {
            if (listBoxItensCompra.SelectedItem is ItemCompra itemSelecionado)
            {
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
                    MessageBox.Show("Item atualizado e adquirido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarDadosCompra(); // Atualiza a lista e DESCONTA NO ORÇAMENTO!
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar item: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Regras 14 e 15: Adicionar Artigo Não Previsto (Entra logo como adquirido)
        private void buttonNaoPrevisto_Click(object sender, EventArgs e)
        {
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
                            QuantidadePrevista = 0, // Como não estava previsto, é zero!
                            QuantidadeAdquirida = (int)numericUpDown1.Value,
                            PrecoUnitario = numericUpDown2.Value,
                            ArtigoPrevisto = false,
                            Observacoes = textBox1.Text
                        };
                        db.ItensCompra.Add(novoItem);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Artigo não previsto adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarDadosCompra(); // Atualiza a lista e DESCONTA NO ORÇAMENTO!
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar item não previsto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Regra 18: Fechar a Compra (Regista quem fechou e a data)
        private void buttonFecharCompra_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = MessageBox.Show("Tem a certeza que deseja fechar esta compra? Não poderá alterá-la depois.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    compraController.FecharCompra(compraIdAtual, UtilizadorController.UtilizadorLogadoId.Value);
                    MessageBox.Show("Compra fechada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Sai do Modo Compra
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            textBox1.Clear();
            listBoxItensCompra.ClearSelected();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}