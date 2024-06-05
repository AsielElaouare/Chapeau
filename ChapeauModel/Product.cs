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
        public string Naam { get; private set; }
        public int Voorraad { get; private set; }
        public decimal Prijs { get; private set; }
        public ProductCategorie Categorie { get; private set; }
        public ProductKaart Kaart { get; private set; }

        public Product(int artikelid, string naam, int voorraad, decimal prijs, string categorie, string kaart)
        {
            Artikelid = artikelid;
            Naam = naam;
            Voorraad = voorraad;
            Prijs = prijs;
            Categorie = (ProductCategorie)Enum.Parse(typeof(ProductCategorie), categorie);
            Kaart = (ProductKaart)Enum.Parse(typeof(ProductKaart), kaart);
        }
        public Product(string naam, string categorie, decimal prijs)
        {
            this.Naam = naam;
            this.Categorie = (ProductCategorie)Enum.Parse(typeof(ProductCategorie), categorie);
            this.Prijs = prijs;
        }
        public Product(string naam, string categorie)
        {
            Naam = naam;
            Categorie = (ProductCategorie)Enum.Parse(typeof(ProductCategorie), categorie);

        }
    }
}
