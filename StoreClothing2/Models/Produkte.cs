using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreClothing2.Models
{
    public class Produkte
    {
        [Key]
        public int IDProdukte { get; set; }
        public string Emri { get; set; }
        public string Imazh { get; set; }
        public decimal Cmimi { get; set; }
        public int Sasi { get; set; }
        public string Pershkrimi { get; set; }
        public int? KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public int InventarID { get; set; }
        public virtual Inventari Inventari { get; set; }
    }
}