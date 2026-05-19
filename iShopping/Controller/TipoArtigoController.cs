using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace iShopping.Controller
{
    public class TipoArtigoController
    {
        public List<TipoArtigo> ObterTodos()
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    return context.TiposArtigo.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter Tipos de Artigo: " + ex.Message);
            }
        }

        public void Adicionar(TipoArtigo novoTipo)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    // Verifica se já existe um tipo com o mesmo nome
                    bool jaExiste = context.TiposArtigo
                        .Any(t => t.Nome.ToLower() == novoTipo.Nome.ToLower());

                    if (jaExiste)
                        throw new Exception("Já existe um Tipo de Artigo com esse nome.");

                    context.TiposArtigo.Add(novoTipo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar Tipo de Artigo: " + ex.Message);
            }
        }

        public void Atualizar(TipoArtigo tipo)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    // Verifica se já existe outro tipo com o mesmo nome (excluindo o próprio)
                    bool jaExiste = context.TiposArtigo
                        .Any(t => t.Nome.ToLower() == tipo.Nome.ToLower() && t.Id != tipo.Id);

                    if (jaExiste)
                        throw new Exception("Já existe um Tipo de Artigo com esse nome.");

                    context.Entry(tipo).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Tipo de Artigo: " + ex.Message);
            }
        }

        public bool Remover(int id)
        {
            try
            {
                using (var context = new iShoppingContext())
                {
                    var tipo = context.TiposArtigo.Find(id);

                    if (tipo == null)
                        throw new Exception("Tipo de Artigo não encontrado.");

                    // Verifica se tem artigos associados — se tiver, não deixa eliminar
                    bool temArtigos = context.Artigos.Any(a => a.TipoArtigoId == id);
                    if (temArtigos)
                        return false; // o Form vai mostrar mensagem adequada

                    context.TiposArtigo.Remove(tipo);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover Tipo de Artigo: " + ex.Message);
            }
        }
    }
}