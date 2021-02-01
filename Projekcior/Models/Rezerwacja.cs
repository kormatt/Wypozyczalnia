using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekcior.Models
{
    public class Rezerwacja
    {
        public int id { get; set; }
        public int Klient { get; set; }
        public int Samochod { get; set; }
        public DateTime dataRozpoczecia { get; set; }
        public DateTime dataZakonczenia { get; set; }
        public decimal cena { get; set; }
    }
}