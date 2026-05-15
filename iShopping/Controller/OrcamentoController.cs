using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controller
{
    public class OrcamentoController
    {

        // Obtém todos os orçamentos existentes na base de dados.
        // Inclui também os utilizadores que criaram ou alteraram cada orçamento.
        public List<Orcamento> ObterTodos()
        {
            using (var context = new iShoppingContext())
            {
                return context.Orcamentos
                    .Include(o => o.CriadoPor)
                    .Include(o => o.AlteradoPor)
                    .OrderBy(o => o.Ano)
                    .ThenBy(o => o.Mes)
                    .ToList();
            }
        }

        // Verifica se já existe um orçamento para o mesmo mês e ano.
        // Isto impede criar dois orçamentos mensais iguais.
        public bool ExisteOrcamentoMensal(int mes, int ano)
        {
            using (var context = new iShoppingContext())
            {
                return context.Orcamentos.Any(o => o.Mes == mes && o.Ano == ano);
            }
        }

        // Verifica se já existe outro orçamento com o mesmo mês e ano.
        // É usado na edição para evitar duplicados.
        public bool ExisteOutroOrcamentoMensal(int id, int mes, int ano)
        {
            using (var context = new iShoppingContext())
            {
                return context.Orcamentos.Any(o =>
                    o.Id != id &&
                    o.Mes == mes &&
                    o.Ano == ano);
            }
        }

        // Adiciona um novo orçamento à base de dados.
        // Recebe um objeto Orcamento já preenchido no formulário.
        // O SaveChanges grava definitivamente a alteração na tabela Orcamentos.
        public void Adicionar(Orcamento orcamento)
        {
            // Cria uma ligação temporária à base de dados.
            using (var context = new iShoppingContext())
            {
                // Adiciona o novo orçamento à tabela Orcamentos.
                context.Orcamentos.Add(orcamento);
                // Grava definitivamente as alterações na base de dados.
                context.SaveChanges();
            }
        }

        // Atualiza um orçamento existente na base de dados.
        // O objeto recebido já vem com os novos dados preenchidos.
        public void Atualizar(Orcamento orcamento)
        {
            using (var context = new iShoppingContext())
            {
                context.Entry(orcamento).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        // Remove um orçamento da base de dados através do seu Id.
        public void Remover(int id)
        {
            using (var context = new iShoppingContext())
            {
                var orcamento = context.Orcamentos.Find(id);

                if (orcamento != null)
                {
                    context.Orcamentos.Remove(orcamento);
                    context.SaveChanges();
                }
            }
        }
    }
}