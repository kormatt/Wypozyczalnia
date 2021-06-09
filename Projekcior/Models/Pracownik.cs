using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekcior.Models
{
    public class Pracownik : Klient
    {
        private static Pracownik Convert(Klient Client) {
            Pracownik ee = new Pracownik();
            ee.id = Client.id;
            ee.email = Client.email;
            ee.haslo = Client.haslo;
            ee.pesel = Client.pesel;
            ee.imie = Client.imie;
            ee.nazwisko = Client.nazwisko;
            ee.adres = Client.adres;
            ee.dataUrodzenia = Client.dataUrodzenia;
            ee.nrTelefonu = Client.nrTelefonu;
            ee.typ = Client.typ;

            return ee;
        }
        public static void DodajSamochod(Samochod car) {

            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "INSERT INTO Samochody (marka, model, nrTablicyRej, nrVin, rocznik, cenaWypozyczenia, iloscMiejsc, dostepny) VALUES " +
                "( @marka ," +
                "@model ," +
                "@nrTablicyRej ," +
                "@nrVin ," +
                "@rocznik ," +
                "@cenaWypozyczenia ," +
                "@iloscMiejsc ," +
                "@dostepny)";

            cmd.AddParameter("@marka", car.idmarka);
            cmd.AddParameter("@model", car.model);
            cmd.AddParameter("@nrTablicyRej", car.nrTablicyRej);
            cmd.AddParameter("@nrVin", car.nrVin);
            cmd.AddParameter("@rocznik", car.rocznik);
            cmd.AddParameter("@cenaWypozyczenia", car.cenaWypozyczenia);
            cmd.AddParameter("@iloscMiejsc", car.iloscMiejsc);
            cmd.AddParameter("@dostepny", car.dostepny);

            cmd.ExecuteNonQuery();
        }
        public static void EdytujSamochod(Samochod car) {

            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "UPDATE Samochody SET " +
                "Samochody.marka = @marka ," +
                "Samochody.model = @model ," +
                "Samochody.nrTablicyRej = @nrTablicyRej ," +
                "Samochody.nrVin = @nrVin ," +
                "Samochody.rocznik = @rocznik ," +
                "Samochody.cenaWypozyczenia = @cenaWypozyczenia ," +
                "Samochody.iloscMiejsc = @iloscMiejsc ," +
                "Samochody.dostepny = @dostepny " +
                "WHERE Samochody.idSamochodu = @id";

            cmd.AddParameter("@id", car.id);
            cmd.AddParameter("@marka", car.idmarka);
            cmd.AddParameter("@model", car.model);
            cmd.AddParameter("@nrTablicyRej", car.nrTablicyRej);
            cmd.AddParameter("@nrVin", car.nrVin);
            cmd.AddParameter("@rocznik", car.rocznik);
            cmd.AddParameter("@cenaWypozyczenia", car.cenaWypozyczenia);
            cmd.AddParameter("@iloscMiejsc", car.iloscMiejsc);
            cmd.AddParameter("@dostepny", car.dostepny);

            cmd.ExecuteNonQuery();


        }
        public static void UsunSamochod(Samochod car) {
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();

            cmd.CommandText= "DELETE FROM Samochody WHERE idSamochodu = @id";
            cmd.AddParameter("@id", car.id);
            cmd.ExecuteNonQuery();
        }
        public static List<Samochod> WyswietlSamochody() {

            List<Samochod> Cars = new List<Samochod>();
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "SELECT * FROM Samochody";

            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Samochod TempCar = new Samochod();
                TempCar.id = reader.GetInt32(0);
                TempCar.idmarka = reader.GetInt16(1);
                TempCar.model = reader.GetString(2);
                TempCar.nrTablicyRej = reader.GetString(3);
                TempCar.nrVin = reader.GetString(4);
                TempCar.rocznik = reader.GetInt16(5);
                TempCar.cenaWypozyczenia = reader.GetFloat(6);
                TempCar.iloscMiejsc = reader.GetInt16(7);
                TempCar.dostepny = reader.GetBoolean(8);

                Cars.Add(TempCar);
            }
            reader.Close();
            return Cars;
        }
        public static List<Marka> WyswietlMarki() {

            List<Marka> brands = new List<Marka>();
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "SELECT * FROM MarkiSamochodow";

            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Marka tempBrand = new Marka();
                tempBrand.id = reader.GetInt32(0);
                tempBrand.nazwa = reader.GetString(1);

                brands.Add(tempBrand);
            }
            reader.Close();
            return brands;
        }
        public static void EdytujKlienta(Klient Klient) {
            Pracownik temEE = Convert(Klient);
            Szef.EdytujPracownika(temEE);
        }
        public static void DodajKlienta(Klient Klient) {
            Pracownik temEE = Convert(Klient);
            Szef.DodajPracownika(temEE,3);

        }
        public static void UsunKlienta(Klient Client) {

            Pracownik temEE = Convert(Client);
            Szef.UsunPracownika(temEE);  

        }
        public static List<Klient> WyswietlKlientow() {

            List<Klient> Clients = new List<Klient>();
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "SELECT * FROM Uzytkownicy WHERE TypKonta = @a";

            //login
            cmd.AddParameter("@a", 3);

            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Klient tempCli = new Klient();
                //id
                tempCli.id = reader.GetInt32(0);
                //email
                tempCli.email = reader.GetString(1);
                //haslo 
                tempCli.haslo = reader.GetString(2);
                //pesel 
                tempCli.pesel = reader.GetInt64(3);
                //imie 
                tempCli.imie = reader.GetString(4);
                //nazwisko 
                tempCli.nazwisko = reader.GetString(5);
                //adres 
                tempCli.adres = reader.GetString(6);
                //dataUrodzenia 
                tempCli.dataUrodzenia = reader.GetDateTime(7);
                //nrTelefonu 
                tempCli.nrTelefonu = reader.GetInt32(8);
                //typ 
                tempCli.typ = reader.GetInt16(9);
                Clients.Add(tempCli);
            }
            reader.Close();
            return Clients;
        }
        public static List<Klient> WyswietlKlienta(int ID) {

            List<Klient> Clients = new List<Klient>();
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "SELECT * FROM Uzytkownicy WHERE idUzytkownika = @a";

            //login
            cmd.AddParameter("@a", ID);

            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Klient tempCli = new Klient();
                //id
                tempCli.id = reader.GetInt32(0);
                //email
                tempCli.email = reader.GetString(1);
                //haslo 
                tempCli.haslo = reader.GetString(2);
                //pesel 
                tempCli.pesel = reader.GetInt64(3);
                //imie 
                tempCli.imie = reader.GetString(4);
                //nazwisko 
                tempCli.nazwisko = reader.GetString(5);
                //adres 
                tempCli.adres = reader.GetString(6);
                //dataUrodzenia 
                tempCli.dataUrodzenia = reader.GetDateTime(7);
                //nrTelefonu 
                tempCli.nrTelefonu = reader.GetInt32(8);
                //typ 
                tempCli.typ = reader.GetInt16(9);
                Clients.Add(tempCli);
            }
            reader.Close();
            return Clients;
        }

        public static void EdytujRezerwacje(Rezerwacja Rentals) {
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "UPDATE Rezerwacje SET " +
                "Rezerwacje.idUzytkownika = @idUzytkownika ," +
                "Rezerwacje.idSamochodu = @idSamochodu ," +
                "Rezerwacje.dataRozpoczecia = @dataRozpoczecia ," +
                "Rezerwacje.dataZakonczenia = @dataZakonczenia ," +
                "Rezerwacje.cena = @cena " +
                "WHERE Rezerwacje.idRezerwacji = @id";

            cmd.AddParameter("@idUzytkownika", Rentals.Klient);
            cmd.AddParameter("@idSamochodu", Rentals.Samochod);
            cmd.AddParameter("@dataRozpoczecia", Rentals.dataRozpoczecia.ToString("yyyy-MM-dd"));
            cmd.AddParameter("@dataZakonczenia", Rentals.dataZakonczenia.ToString("yyyy-MM-dd"));
            cmd.AddParameter("@cena", Rentals.cena);
            cmd.AddParameter("@id", Rentals.id);


            cmd.ExecuteNonQuery();

        }
        public static void DodajRezerwacje(Rezerwacja Rentals) {
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "INSERT INTO Rezerwacje ( idUzytkownika, idSamochodu, dataRozpoczecia, dataZakonczenia, cena, idUbezpieczenia) VALUES " +
                                                      "(@idUzytkownika ,@idSamochodu, @dataRozpoczecia, @dataZakonczenia, @cena ,@idubez); ";

            cmd.AddParameter("@idUzytkownika", Rentals.Klient);
            cmd.AddParameter("@idSamochodu", Rentals.Samochod);
            cmd.AddParameter("@dataRozpoczecia", Rentals.dataRozpoczecia.ToString("yyyy-MM-dd"));
            cmd.AddParameter("@dataZakonczenia", Rentals.dataZakonczenia.ToString("yyyy-MM-dd"));
            cmd.AddParameter("@cena", Rentals.cena);
            cmd.AddParameter("@idubez", 3);

            cmd.ExecuteNonQuery();

        }

        public static void UsunRezerwacje(Rezerwacja Rentals) {

            var con = Database.GetConnection();
            var cmd = con.CreateCommand();

            cmd.CommandText = "DELETE FROM Rezerwacje WHERE idRezerwacji=@id";
            cmd.AddParameter("@id", Rentals.id);
            cmd.ExecuteNonQuery();
        }
        public static List<Rezerwacja> PokazRezerwacje() {
            List<Rezerwacja> Rentals = new List<Rezerwacja>();

            var con = Database.GetConnection();
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM `Rezerwacje` " +
                                "LEFT JOIN Uzytkownicy ON Rezerwacje.idUzytkownika = Uzytkownicy.idUzytkownika " +
                                "LEFT JOIN Samochody ON Rezerwacje.idSamochodu = Samochody.idSamochodu";

            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Rezerwacja rent = new Rezerwacja();

                rent.id = reader.GetInt32(0);
                rent.dataRozpoczecia = reader.GetDateTime(3);
                rent.dataZakonczenia = reader.GetDateTime(4);
                rent.cena = reader.GetInt32(5);
                rent.Klient = reader.GetInt32(7);
                //car data
                rent.Samochod = reader.GetInt32(17);
                
                Rentals.Add(rent);
            }
            reader.Close();

            return Rentals;
        }
        public static List<Rezerwacja> PokazRezerwacje(int userid) {
            List<Rezerwacja> Rentals = new List<Rezerwacja>();

            var con = Database.GetConnection();
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM `Rezerwacje` LEFT JOIN Uzytkownicy ON Rezerwacje.idUzytkownika = Uzytkownicy.idUzytkownika LEFT JOIN Samochody ON Rezerwacje.idSamochodu = Samochody.idSamochodu WHERE Rezerwacje.idUzytkownika = @id";
            cmd.AddParameter("@id", userid);
            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Rezerwacja rent = new Rezerwacja();

                rent.id = reader.GetInt32(0);
                rent.dataRozpoczecia = reader.GetDateTime(3);
                rent.dataZakonczenia = reader.GetDateTime(4);
                rent.cena = reader.GetInt32(5);
                rent.Klient = reader.GetInt32(7);
                //car data
                rent.Samochod = reader.GetInt32(17);

                Rentals.Add(rent);
            }
            reader.Close();

            return Rentals;
        }
    }
}