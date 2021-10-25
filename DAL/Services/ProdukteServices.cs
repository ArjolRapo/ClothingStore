using System;
using System.Collections.Generic;
using System.Text;
using StoreClothing2.Models;

namespace DAL.Services
{
    public class ProdukteServices
    {
        public Produkte Create(Produkte produkte)
        {
            Produktes.Add(produkte);
            db.SaveChanges();
        }

    }
}
