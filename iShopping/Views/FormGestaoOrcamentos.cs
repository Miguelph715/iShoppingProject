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
            
            // Carrega os orçamentos existentes na ListBox.
            AtualizarLista();

            //Limpa o campo valores e remove seleções
            LimparCampos();

            // Coloca o calendário na data atual.
            dateTimePickerDataOrcamento.Value = DateTime.Today;
        }

        private void listBoxOrcamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxOrcamentos.SelectedItem is Orcamento orcamentoSelecionado)
            {
                // Como o orçamento guarda apenas mês e ano,
                // criamos uma data com o dia 1 desse mês para preencher o DateTimePicker.
                dateTimePickerDataOrcamento.Value = new DateTime(
                    orcamentoSelecionado.Ano,
                    orcamentoSelecionado.Mes,
                    1);

                textBoxValor.Text = orcamentoSelecionado.Valor.ToString();
            }
        }

        private bool ValidarCampos(out int mes, out int ano, out decimal valor)
        {
            // Inicializa as variáveis para evitar erros caso a validação falhe.
            mes = 0;
            ano = 0;
            valor = 0;

            // Vai buscar a data selecionada no DateTimePicker.
            DateTime dataSelecionada = dateTimePickerDataOrcamento.Value.Date;

            // Como o orçamento é mensal, retiramos apenas o mês e o ano da data escolhida.
            mes = dataSelecionada.Month;
            ano = dataSelecionada.Year;

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

                // Atualiza os dados do orçamento
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

        // Atualiza a ListBox para mostrar o novo orçamento.
        private void AtualizarLista()
        {
            listBoxOrcamentos.DataSource = null;
            listBoxOrcamentos.DataSource = orcamentoController.ObterTodos();

            // Remove seleção automática da lista.
            listBoxOrcamentos.ClearSelected();
        }

        // Limpa os campos depois de gravar, editar, eliminar ou carregar no botão limpar.
        private void LimparCampos()
        {
            // Volta a colocar a data atual no DateTimePicker.
            dateTimePickerDataOrcamento.Value = DateTime.Today;
            textBoxValor.Clear();

            listBoxOrcamentos.ClearSelected();
            textBoxValor.Focus();
        }

    }
}
