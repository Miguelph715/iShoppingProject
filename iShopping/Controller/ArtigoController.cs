using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controller
{
    public class ArtigoController
    {
        public List<Artigo> ObterTodos()
        {
            using (var context = new iShoppingContext())
            {
                // O .Include traz a informação do Tipo de Artigo associado
                return context.Artigos.Include(a => a.TipoArtigo).ToList();
            }
        }

        // Método novo para o Filtro!
        public List<Artigo> ObterPorTipo(int tipoArtigoId)
        {
            using (var context = new iShoppingContext())
            {
                return context.Artigos.Include(a => a.TipoArtigo)
                              .Where(a => a.TipoArtigoId == tipoArtigoId)
                              .ToList();
            }
        }

        public void Adicionar(Artigo artigo)
        {
            using (var context = new iShoppingContext())
            {
                context.Artigos.Add(artigo);
                context.SaveChanges();
            }
        }

        public void Atualizar(Artigo artigo)
        {
            using (var context = new iShoppingContext())
            {
                context.Entry(artigo).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            using (var context = new iShoppingContext())
            {
                var artigo = context.Artigos.Find(id);
                if (artigo != null)
                {
                    context.Artigos.Remove(artigo);
                    context.SaveChanges();
                }
            }
        }
    }
}
