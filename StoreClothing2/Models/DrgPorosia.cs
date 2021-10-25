using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreClothing2.Models
{
    public class DrgPorosia
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Rruga { get; set; }
        public string Qyteti { get; set; }
        public string Shteti { get; set; }
        public int KodiPostal { get; set; }
        public string Telefon { get; set; }
        public virtual Inventari Inventar { get; set; }
        public virtual Produkte Produkti { get; set; }
    }
}