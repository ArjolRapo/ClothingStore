using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreClothing2.Models
{
    public class Kategori
    {
        [Key]
        public int IDKategori { get; set; }
        public string Emri { get; set; }
        public string Imazh { get; set; }
        public string Pershkrimi { get; set; }
        public virtual ICollection<Produkte> Produktes { get; set; }
    }
}