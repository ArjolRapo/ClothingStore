using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreClothing2.Models
{
    public class Shporta
    {
        [Key]
        public int IDShoprta { get; set; }

        public int Sasia { get; set; }

        public string IdPerdorues { get; set; }
        
        public virtual Produkte Produkti { get; set; }

    }
}