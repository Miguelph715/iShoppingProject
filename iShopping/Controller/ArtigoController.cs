using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace iShopping.Controller
{
    public class ArtigoController
    {
        public List<Artigo> ObterTodos()
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    return context.Artigos.Include(a => a.TipoArtigo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter Artigos: " + ex.Message);
            }
        }

        public List<Artigo> ObterPorTipo(int tipoArtigoId)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    return context.Artigos.Include(a => a.TipoArtigo)
                                  .Where(a => a.TipoArtigoId == tipoArtigoId)
                                  .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao filtrar Artigos por Tipo: " + ex.Message);
            }
        }

        public void Adicionar(Artigo artigo)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    // Verifica nome duplicado dentro do mesmo tipo
                    bool jaExiste = context.Artigos
                        .Any(a => a.Nome.ToLower() == artigo.Nome.ToLower()
                               && a.TipoArtigoId == artigo.TipoArtigoId);

                    if (jaExiste)
                        throw new Exception("Já existe um Artigo com esse nome neste Tipo de Artigo.");

                    context.Artigos.Add(artigo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar Artigo: " + ex.Message);
            }
        }

        public void Atualizar(int id, string nome, int tipoArtigoId)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    nome = nome.Trim();

                    // Verifica nome duplicado dentro do mesmo tipo, excluindo o próprio artigo
                    bool jaExiste = context.Artigos
                        .Any(a => a.Nome.ToLower() == nome.ToLower()
                               && a.TipoArtigoId == tipoArtigoId
                               && a.Id != id);

                    if (jaExiste)
                        throw new Exception("Já existe um Artigo com esse nome neste Tipo de Artigo.");

                    Artigo artigoBD = context.Artigos.Find(id);

                    if (artigoBD == null)
                        throw new Exception("Artigo não encontrado.");

                    artigoBD.Nome = nome;
                    artigoBD.TipoArtigoId = tipoArtigoId;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Artigo: " + ex.Message);
            }
        }

        /*public void Atualizar(Artigo artigo)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    // Verifica nome duplicado dentro do mesmo tipo (excluindo o próprio)
                    bool jaExiste = context.Artigos
                        .Any(a => a.Nome.ToLower() == artigo.Nome.ToLower()
                               && a.TipoArtigoId == artigo.TipoArtigoId
                               && a.Id != artigo.Id);

                    if (jaExiste)
                        throw new Exception("Já existe um Artigo com esse nome neste Tipo de Artigo.");

                    context.Entry(artigo).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Artigo: " + ex.Message);
            }
        }*/

        public void Remover(int id)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    var artigo = context.Artigos.Find(id);

                    if (artigo == null)
                        throw new Exception("Artigo não encontrado.");

                    bool usadoEmCompra = context.ItensCompra.Any(i => i.ArtigoId == id);
                    if (usadoEmCompra)
                        throw new Exception("Não é possível eliminar este artigo porque está associado a uma ou mais compras.");

                    context.Artigos.Remove(artigo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover Artigo: " + ex.Message);
            }
        }
    }
}