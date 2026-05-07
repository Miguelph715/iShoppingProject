using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Model
{
    public class iShoppingContext : DbContext
    {
        public iShoppingContext() : base("name=iShoppingContext")
        {
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<TipoArtigo> TiposArtigo { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompra { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Desligar o Cascade Delete para resolver o erro do SQL Server
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }

}
