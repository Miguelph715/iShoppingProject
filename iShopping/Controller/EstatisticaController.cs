using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controller
{
    public class EstatisticaController
    {
        // 1. Orçamentos vs Compras por Mês (Para a primeira ListBox)
        public List<string> ObterEstatisticasMensais()
        {
            List<string> estatisticas = new List<string>();
            int anoAtual = DateTime.Now.Year;

            using (var context = new iShoppingContext())
            {
                // Vai buscar os orçamentos e as compras (com os respetivos itens) apenas do ano atual
                var orcamentos = context.Orcamentos.Where(o => o.Ano == anoAtual).ToList();
                var compras = context.Compras.Include(c => c.ItensCompra).Where(c => c.DataCriacao.Year == anoAtual).ToList();

                // Percorre os 12 meses do ano
                for (int mes = 1; mes <= 12; mes++)
                {
                    // Encontra o orçamento definido para este mês específico
                    var orcamentoMes = orcamentos.FirstOrDefault(o => o.Mes == mes);
                    decimal valorOrcamento = orcamentoMes != null ? orcamentoMes.Valor : 0m;

                    // Encontra todas as compras feitas neste mês
                    var comprasMes = compras.Where(c => c.DataCriacao.Month == mes).ToList();
                    decimal totalGasto = 0m;

                    foreach (var compra in comprasMes)
                    {
                        // Soma (Preço * Quantidade) de todos os itens dessa compra
                        totalGasto += compra.ItensCompra.Sum(i => i.PrecoUnitario * i.QuantidadeAdquirida);
                    }

                    // Se houve orçamento ou compras nesse mês, adicionamos à lista
                    if (valorOrcamento > 0 || totalGasto > 0)
                    {
                        decimal diferenca = valorOrcamento - totalGasto;
                        estatisticas.Add($"Mês {mes:00}/{anoAtual}: Orçamento: {valorOrcamento:C} | Gasto: {totalGasto:C} | Diferença: {diferenca:C}");
                    }
                }
            }

            if (estatisticas.Count == 0)
                estatisticas.Add($"Sem dados de orçamentos ou compras para {anoAtual}.");

            return estatisticas;
        }

        // 2. Percentagens de Artigos Previstos vs Não Previstos (Para a segunda ListBox)
        public List<string> ObterEstatisticasPercentagemArtigos()
        {
            List<string> estatisticas = new List<string>();

            using (var context = new iShoppingContext())
            {
                // Filtra apenas as compras que já foram fechadas
                var comprasFechadas = context.Compras.Include(c => c.ItensCompra).Where(c => c.Fechada).ToList();

                foreach (var compra in comprasFechadas)
                {
                    int totalItens = compra.ItensCompra.Count;
                    if (totalItens > 0)
                    {
                        // Conta quantos itens têm a flag ArtigoPrevisto a true e false
                        int previstos = compra.ItensCompra.Count(i => i.ArtigoPrevisto);
                        int naoPrevistos = compra.ItensCompra.Count(i => !i.ArtigoPrevisto);

                        // Regra de três simples para calcular a percentagem (é preciso converter para double para ter casas decimais)
                        double percPrevistos = ((double)previstos / totalItens) * 100;
                        double percNaoPrevistos = ((double)naoPrevistos / totalItens) * 100;

                        estatisticas.Add($"{compra.NomeCompra} | Previstos: {percPrevistos:F1}% | Extra: {percNaoPrevistos:F1}%");
                    }
                }
            }

            if (estatisticas.Count == 0)
                estatisticas.Add("Ainda não existem compras fechadas.");

            return estatisticas;
        }
    }
}
