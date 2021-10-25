using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreClothing2.Models
{
    public class Porosia
    {
        [Key]
        public int IDPorosia { get; set; }
        public int Sasi { get; set; }
        public int ProduktID { get; set; }
        public virtual Produkte Produkte { get; set; }
        public int IDuser { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}