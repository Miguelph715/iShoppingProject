using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Model
{
    public class TipoArtigo
    {
        public int Id { get; set; }
                
        public string Nome { get; set; }

        public virtual ICollection<Artigo> Artigos { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
