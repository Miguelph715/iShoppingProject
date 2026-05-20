using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Model
{
    public class Compra
    {
        public int Id { get; set; }
        
        public string NomeCompra { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Fechada { get; set; }

        public DateTime? DataFechada { get; set; }

        public int CriadoPorId { get; set; }
        public virtual Utilizador CriadoPor { get; set; }

        public int? AlteradoPorId { get; set; }
        public virtual Utilizador AlteradoPor { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int? FechadoPorId { get; set; }
        public virtual Utilizador FechadoPor { get; set; }

        public virtual ICollection<ItemCompra> ItensCompra { get; set; }

        public override string ToString()
        {
            if (Fechada)
                return NomeCompra + " - Fechada";

            return NomeCompra + " - Aberta";
        }
    }
}
