using iShopping.Controller;
using iShopping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormGestaoOrcamentos: Form
    {
        private OrcamentoController orcamentoController;

        public FormGestaoOrcamentos()
        {
            InitializeComponent();
            // Cria o controller responsável pela gestão dos orçamentos.
            // Sem isto, o orcamentoController fica null e dá erro ao adicionar.
            orcamentoController = new OrcamentoController();

            AtualizarLista();
        }

        private void listBoxOrcamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxOrcamentos.SelectedItem is Orcamento orcamentoSelecionado)
            {
                textBoxMes.Text = orcamentoSelecionado.Mes.ToString();
                textBoxAno.Text = orcamentoSelecionado.Ano.ToString();
                textBoxValor.Text = orcamentoSelecionado.Valor.ToString();
            }
        }

        private bool ValidarCampos(out int mes, out int ano, out decimal valor)
        {
            // Inicializa as variáveis para evitar erros caso a validação falhe.
            mes = 0;
            ano = 0;
            valor = 0;

            // Valida se o mês é um número e se está entre 1 e 12.
            if (!int.TryParse(textBoxMes.Text.Trim(), out mes) || mes < 1 || mes > 12)
            {
                MessageBox.Show(
                    "O mês deve ser um número entre 1 e 12.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            // Valida se o ano é um número válido.
            if (!int.TryParse(textBoxAno.Text.Trim(), out ano) || ano < 2000)
            {
                MessageBox.Show(
                    "Insira um ano válido.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            // Valida se o valor é um número decimal e se é superior a zero.
            if (!decimal.TryParse(textBoxValor.Text.Trim(), out valor) || valor <= 0)
            {
                MessageBox.Show(
                    "Insira um valor válido superior a 0.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            // Se chegou aqui, significa que todos os campos estão corretos.
            return true;
        }
        private void buttonAdicionarOrcamento_Click(object sender, EventArgs e)
        {
            // Valida os campos do formulário.
            // Se algum campo estiver errado, o método termina aqui.
            if (!ValidarCampos(out int mes, out int ano, out decimal valor))
                return;

            // Verifica se existe um utilizador com sessão iniciada.
            // O enunciado pede que cada registo fique associado ao utilizador logado.
            if (UtilizadorController.UtilizadorLogadoId == null)
            {
                MessageBox.Show(
                    "Não existe nenhum utilizador com sessão iniciada.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Verifica se já existe um orçamento para o mesmo mês e ano.
            // O enunciado diz que deve existir apenas um orçamento mensal.
            if (orcamentoController.ExisteOrcamentoMensal(mes, ano))
            {
                MessageBox.Show(
                    "Já existe um orçamento registado para esse mês e ano.",
                    "Orçamento existente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Cria um novo objeto Orçamento com os dados escritos no formulário.
            Orcamento novoOrcamento = new Orcamento
            {
                Mes = mes,
                Ano = ano,
                Valor = valor,

                // Guarda o utilizador que criou o orçamento.
                CriadoPorId = UtilizadorController.UtilizadorLogadoId.Value,
                // Guarda a data e hora de criação.
                DataCriacao = DateTime.Now
            };

            // Envia o orçamento para o controller.
            // O controller é que grava na base de dados através do Entity Framework.
            orcamentoController.Adicionar(novoOrcamento);

            // Mostra uma mensagem de sucesso ao utilizador.
            MessageBox.Show(
                "Orçamento adicionado com sucesso.",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Atualiza a ListBox para mostrar o novo orçamento.
            AtualizarLista();
            // Limpa os campos depois de gravar.
            LimparCampos();
        }


        // Atualiza a ListBox para mostrar o novo orçamento.
        private void AtualizarLista()
        {
            listBoxOrcamentos.DataSource = null;
            listBoxOrcamentos.DataSource = orcamentoController.ObterTodos();
        }
        // Limpa os campos depois de gravar.
        private void LimparCampos()
        {
            textBoxMes.Clear();
            textBoxAno.Clear();
            textBoxValor.Clear();

            listBoxOrcamentos.ClearSelected();
            textBoxMes.Focus();
        }

        private void buttonEditarOrcamento_Click(object sender, EventArgs e)
        {
            if (listBoxOrcamentos.SelectedItem is Orcamento orcamentoSelecionado)
            {
                if (!ValidarCampos(out int mes, out int ano, out decimal valor))
                    return;

                // Verifica se ao alterar o mês/ano, não vai colidir com outro orçamento já existente

                if (orcamentoController.ExisteOutroOrcamentoMensal(orcamentoSelecionado.Id, mes, ano))
                {
                    MessageBox.Show("Já existe outro orçamento registado para esse mês e ano.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Atualiza os dados
                orcamentoSelecionado.Mes = mes;
                orcamentoSelecionado.Ano = ano;
                orcamentoSelecionado.Valor = valor;

                // CUMPRIR REGRA 8 - Registar quem alterou e a data
                orcamentoSelecionado.AlteradoPorId = UtilizadorController.UtilizadorLogadoId;
                orcamentoSelecionado.DataAlteracao = DateTime.Now;

                orcamentoController.Atualizar(orcamentoSelecionado);

                MessageBox.Show("Orçamento atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizarLista();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um orçamento na lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buttonEliminarOrcamento_Click(object sender, EventArgs e)
        {
            if (listBoxOrcamentos.SelectedItem is Orcamento orcamentoSelecionado)
            {
                DialogResult resposta = MessageBox.Show(
                    $"Tem a certeza que deseja eliminar o orçamento de {orcamentoSelecionado.Mes}/{orcamentoSelecionado.Ano}?",
                    "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    orcamentoController.Remover(orcamentoSelecionado.Id);
                    MessageBox.Show("Orçamento eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AtualizarLista();
                    LimparCampos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um orçamento na lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLimparOrcamento_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        
    }
}

