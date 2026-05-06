using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Model
{
    public class ItemCompra
    {
        public int Id { get; set; }

        public int CompraId { get; set; }
        public virtual Compra Compra { get; set; }

        public int ArtigoId { get; set; }
        public virtual Artigo Artigo { get; set; }

        public bool ArtigoPrevisto { get; set; }

        public int QuantidadePrevista { get; set; }

        public int QuantidadeAdquirida { get; set; }

        public decimal PrecoUnitario { get; set; }

        public string Observacoes { get; set; }

        public int CriadoPorId { get; set; }
        public virtual Utilizador CriadoPor { get; set; }

        public int? AlteradoPorId { get; set; }
        public virtual Utilizador AlteradoPor { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public override string ToString()
        {
            return Artigo + " - Previsto: " + QuantidadePrevista + " / Adquirido: " + QuantidadeAdquirida;
        }
    }
}
