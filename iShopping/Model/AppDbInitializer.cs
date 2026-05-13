using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Model
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<iShoppingContext>
    {
        protected override void Seed(iShoppingContext context)
        {
            // Alterar para o vosso context
            context.Utilizadores.Add(new Utilizador { Username = "Test User", Password = "123" });
            base.Seed(context);
        }
    }
}
