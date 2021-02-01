using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekcior.Models {
    public interface IAccommodatable {
        //wszystkie klasy na public
        int id { get; set; }
        string email { get; set; }
        string haslo { get; set; }
        long pesel { get; set; }
        string imie { get; set; }
        string nazwisko { get; set; }
        string adres { get; set; }
        DateTime dataUrodzenia { get; set; }
        int nrTelefonu { get; set; }
        int typ { get; set; }
        //that does not exist in db
        string daneOsobowe { get; set; }
    }
}