using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreClothing2.Models
{
    public class Inventari
    {
        [Key]
        public int IDinventari { get; set; }
        public int SasiTotale { get; set; }
        public virtual ICollection<Produkte> Produktes { get; set; }

    }
}