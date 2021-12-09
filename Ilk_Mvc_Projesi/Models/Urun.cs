using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.Models
{
    public class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
    }
    public static class UrunManager
    {
        public static List<Urun> GetUrunler()
        {
            var List = new List<Urun>();
            List.Add(new Urun()
            {
                Ad = "Kitap",
                Fiyat = 15
            });
            List.Add(new Urun()
            {
                Ad = "Defter",
                Fiyat = 7
            });
            List.Add(new Urun()
            {
                Ad = "Kalem",
                Fiyat = 5
            });
            return List;
        }

    }
}