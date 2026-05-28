using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Model
{
    public class Utilizador
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}
