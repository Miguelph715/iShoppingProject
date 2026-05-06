using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controller
{
    public class TipoArtigoController
    {
        public List<TipoArtigo> ObterTodos()
        {
            using (var context = new iShoppingContext())
            {
                // Substitui 'TiposArtigo' pelo nome exato do teu DbSet no iShoppingContext.cs
                return context.TiposArtigo.ToList();
            }
        }

        public void Adicionar(TipoArtigo novoTipo)
        {
            using (var context = new iShoppingContext())
            {
                context.TiposArtigo.Add(novoTipo);
                context.SaveChanges(); // Guarda as alterações na Base de Dados
            }
        }

        public void Atualizar(TipoArtigo tipo)
        {
            using (var context = new iShoppingContext())
            {
                // Informa o Entity Framework que este objeto foi modificado
                context.Entry(tipo).State = System.Data.Entity.EntityState.Modified;
                // Nota: se estiveres a usar EF Core em vez de EF6, a linha acima pode ser apenas: context.TiposArtigo.Update(tipo);

                context.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            using (var context = new iShoppingContext())
            {
                // Procura o artigo pelo ID
                var tipoParaRemover = context.TiposArtigo.Find(id);

                if (tipoParaRemover != null)
                {
                    context.TiposArtigo.Remove(tipoParaRemover); // Remove do contexto
                    context.SaveChanges(); // Elimina efetivamente da Base de Dados
                }
            }
        }
    }
}
