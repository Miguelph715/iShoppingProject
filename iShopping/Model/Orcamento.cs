using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Model
{
    public class Orcamento
    {
        public int Id { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public decimal Valor { get; set; }

        public int CriadoPorId { get; set; }
        public virtual Utilizador CriadoPor { get; set; }

        public int? AlteradoPorId { get; set; }
        public virtual Utilizador AlteradoPor { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        /*public override string ToString()
        {
            return Mes + "/" + Ano + " - " + Valor.ToString("C");
        }*/

        public override string ToString()
        {
            string nomeMes = new DateTime(Ano, Mes, 1)
                .ToString("MMMM", new System.Globalization.CultureInfo("pt-PT"));

            nomeMes = char.ToUpper(nomeMes[0]) + nomeMes.Substring(1);

            return nomeMes + " - " + Ano + " - " + Valor.ToString("C");
        }
    }
}
