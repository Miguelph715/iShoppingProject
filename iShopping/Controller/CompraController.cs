using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace iShopping.Controller
{
    public class CompraController
    {
        // =========================================================================
        // 1. MÉTODOS BASE (CRUD com tratamento de erros - Regra 21)
        // =========================================================================

        /// <summary>
        /// Obtém todas as compras registadas com os respetivos utilizadores e itens.
        /// </summary>
        public List<Compra> ObterTodas()
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    return context.Compras
                        .Include(c => c.CriadoPor)
                        .Include(c => c.FechadoPor)
                        .Include(c => c.ItensCompra)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                // Captura falhas de ligação ou leitura e lança uma mensagem amigável
                throw new Exception("Erro ao obter a listagem de compras: " + ex.Message);
            }
        }

        /// <summary>
        /// Procura uma compra específica através do seu ID.
        /// </summary>
        public Compra ObterPorId(int id)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    return context.Compras
                        .Include(c => c.ItensCompra.Select(i => i.Artigo))
                        .FirstOrDefault(c => c.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar os detalhes da compra: " + ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um planeamento de compra inicial à base de dados.
        /// </summary>
        public void Adicionar(Compra compra)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    context.Compras.Add(compra);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registar a nova compra: " + ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma compra (Garante a Regra 12 do enunciado).
        /// </summary>
        public void Atualizar(Compra compra)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    var compraExistente = context.Compras.Find(compra.Id);

                    if (compraExistente == null)
                        throw new Exception("A compra que tenta alterar não foi encontrada.");

                    // REGRA 12: O Utilizador pode alterar uma Compra apenas se esta não estiver fechada
                    if (compraExistente.Fechada)
                        throw new Exception("Operação Inválida! Não é possível alterar uma compra que já se encontra fechada.");

                    // Atualiza os valores do cabeçalho
                    context.Entry(compraExistente).CurrentValues.SetValues(compra);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Mantém a mensagem original caso tenha sido uma validação de negócio nossa
                throw new Exception("Erro ao atualizar a compra: " + ex.Message);
            }
        }

        /// <summary>
        /// Remove uma compra caso esta ainda esteja em planeamento (aberta).
        /// </summary>
        public void Remover(int id)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    var compra = context.Compras.Find(id);

                    if (compra != null)
                    {
                        // Proteção de dados: Compras fechadas guardam histórico e não podem ser apagadas
                        if (compra.Fechada)
                            throw new Exception("Não é permitido eliminar uma compra que já foi concluída e fechada.");

                        context.Compras.Remove(compra);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao eliminar a compra: " + ex.Message);
            }
        }

        // =========================================================================
        // 2. MÉTODOS ESPECÍFICOS DO MODO COMPRA
        // =========================================================================

        /// <summary>
        /// REGRA 18: Conclui a compra e grava em definitivo quem a fechou e a data/hora exata.
        /// </summary>
        public void FecharCompra(int compraId, int utilizadorId)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    var compra = context.Compras.Find(compraId);

                    if (compra == null)
                        throw new Exception("Compra não encontrada.");

                    if (compra.Fechada)
                        throw new Exception("Esta compra já se encontra fechada.");

                    // Aplica os dados de fecho exigidos no enunciado
                    compra.Fechada = true;
                    compra.DataFechada = DateTime.Now;
                    compra.FechadoPorId = utilizadorId;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao finalizar a compra: " + ex.Message);
            }
        }

        /// <summary>
        /// REGRA 16: Calcula em tempo real o saldo restante do orçamento familiar para o mês.
        /// </summary>
        public decimal ObterOrcamentoDisponivel(int mes, int ano)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    // 1. Procura o orçamento máximo definido para o respetivo mês/ano
                    var orcamentoMensal = context.Orcamentos.FirstOrDefault(o => o.Mes == mes && o.Ano == ano);

                    // Se a família não definiu orçamento para este mês, o saldo disponível começa em 0
                    if (orcamentoMensal == null)
                        return 0;

                    // 2. Soma o total real gasto em todas as linhas de itens adquiridos neste mês
                    var totalGasto = context.ItensCompra
                        .Where(i => i.Compra.DataCriacao.Month == mes && i.Compra.DataCriacao.Year == ano)
                        .Sum(i => (decimal?)(i.QuantidadeAdquirida * i.PrecoUnitario)) ?? 0;

                    // 3. Devolve a margem atual (Orçamento Total - Total Gasto)
                    return orcamentoMensal.Valor - totalGasto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar o orçamento disponível: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtém todas as compras que ainda não foram fechadas (em aberto).
        /// </summary>
        public List<Compra> ObterComprasAbertas()
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    return context.Compras
                        .Include(c => c.CriadoPor)
                        .Where(c => c.Fechada == false)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter compras em aberto: " + ex.Message);
            }
        }
    }
}