using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Product
    {
        public int Artikelid { get; private set; }
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Prijs { get; private set; }
        public int Quantity { get; private set; }
        public string Comment { get; private set; }
        public ProductCategorie Category { get; private set; }
        public ProductKaart Menu { get; private set; }

        public Product(int artikelid, string naam, int voorraad, decimal prijs, string categorie, string kaart)
        {
            Artikelid = artikelid;
            Name = naam;
            Stock = voorraad;
            Prijs = prijs;
            Category = (ProductCategorie)Enum.Parse(typeof(ProductCategorie), categorie);
            Menu = (ProductKaart)Enum.Parse(typeof(ProductKaart), kaart);
        }
        public Product(string naam, string categorie)
        {
            Name = naam;
            Category = (ProductCategorie)Enum.Parse(typeof(ProductCategorie), categorie);
        }
        public Product(string naam, string categorie, int quantity, string comment)
        {
            Name = naam;
            Category = (ProductCategorie)Enum.Parse(typeof(ProductCategorie), categorie);
            this.Quantity = quantity;
            this.Comment = comment;
        }
        public Product(string naam, string categorie, decimal prijs)
        {
            this.Name = naam;
            this.Category = (ProductCategorie)Enum.Parse(typeof(ProductCategorie), categorie);
            this.Prijs = prijs;
        }
    }
}
