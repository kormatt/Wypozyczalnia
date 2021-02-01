using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekcior.Models {
    public class MultipleList2 {
        public List<Rezerwacja> Rentals { get; set; }
        public List<Klient> Clients { get; set; }
        public List<Samochod> Cars { get; set; }
        public List<Marka> Brands { get; set; }
    }
}