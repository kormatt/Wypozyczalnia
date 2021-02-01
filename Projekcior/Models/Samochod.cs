using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekcior.Models
{
    public class Samochod
    {
        public int id { get; set; }
        public string marka { get; set; }
        public int idmarka { get; set; }
        public string model { get; set; }
        public string nrTablicyRej { get; set; }
        public string nrVin { get; set; }
        public int rocznik { get; set; }
        public float cenaWypozyczenia { get; set; }
        public int iloscMiejsc { get; set; }
        public bool dostepny { get; set; }
    }
}