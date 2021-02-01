using System.Collections.Generic;

namespace Projekcior.Models
{
    public class Szef : Pracownik
    {
        public static void DodajPracownika(Pracownik Pracownik) {
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Uzytkownicy (email, haslo, pesel, imie, nazwisko, adres, dataUrodzenia, nrTelefonu, TypKonta) VALUES (@email ,@passwd ,@pesel ,@name ,@surname ,@adress, @date, @phone, 2)";



            cmd.AddParameter("@email", Pracownik.email);
            cmd.AddParameter("@passwd", Pracownik.haslo);
            cmd.AddParameter("@pesel", Pracownik.pesel);
            cmd.AddParameter("@name", Pracownik.imie);
            cmd.AddParameter("@surname", Pracownik.nazwisko);
            cmd.AddParameter("@adress", Pracownik.adres);
            cmd.AddParameter("@date", Pracownik.dataUrodzenia);
            cmd.AddParameter("@phone", Pracownik.nrTelefonu);

            cmd.ExecuteNonQuery();
        }
        public static void DodajPracownika(Pracownik Pracownik, int typ) {
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Uzytkownicy (email, haslo, pesel, imie, nazwisko, adres, dataUrodzenia, nrTelefonu, TypKonta) VALUES (@email ,@passwd ,@pesel ,@name ,@surname ,@adress, @date, @phone, @type)";
            cmd.AddParameter("@email", Pracownik.email);
            cmd.AddParameter("@passwd", Pracownik.haslo);
            cmd.AddParameter("@pesel", Pracownik.pesel);
            cmd.AddParameter("@name", Pracownik.imie);
            cmd.AddParameter("@surname", Pracownik.nazwisko);
            cmd.AddParameter("@adress", Pracownik.adres);
            cmd.AddParameter("@date", Pracownik.dataUrodzenia);
            cmd.AddParameter("@phone", Pracownik.nrTelefonu);
            cmd.AddParameter("@type", typ);

            cmd.ExecuteNonQuery();
        }

        //zmiana na przekazanie w parametrze pracownika, zmiana typu funkcji na static zeby mozna bylo bez tworzenia obiektu wywolywac funkcje
        public static void EdytujPracownika(Pracownik Pracownik) {

            var con = Database.GetConnection();
            var cmd = con.CreateCommand();

            cmd.CommandText = "UPDATE Uzytkownicy SET " +
                "email = @email ," +
                "haslo = @passwd ," +
                "pesel = @pesel ," +
                "imie = @name ," +
                "nazwisko = @surname ," +
                "adres = @adress ," +
                "dataUrodzenia = @date ," +
                "nrTelefonu = @phone ," +
                "TypKonta = @type " +
                "WHERE idUzytkownika = @id";

            cmd.AddParameter("@id", Pracownik.id);
            cmd.AddParameter("@email", Pracownik.email);
            cmd.AddParameter("@passwd", Pracownik.haslo);
            cmd.AddParameter("@pesel", Pracownik.pesel);
            cmd.AddParameter("@name", Pracownik.imie);
            cmd.AddParameter("@surname", Pracownik.nazwisko);
            cmd.AddParameter("@adress", Pracownik.adres);
            cmd.AddParameter("@date", Pracownik.dataUrodzenia.ToString("yyyy-MM-dd"));
            cmd.AddParameter("@phone", Pracownik.nrTelefonu);
            cmd.AddParameter("@type", Pracownik.typ);

            cmd.ExecuteNonQuery();

        }

        public static void UsunPracownika(Pracownik Pracownik) {

            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Uzytkownicy WHERE idUzytkownika = @a";

            cmd.AddParameter("@a", Pracownik.id);

            cmd.ExecuteNonQuery();

        }

        public static List<Pracownik> WyswietlPracownikow() {

            List<Pracownik> employees = new List<Pracownik>();
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "SELECT * FROM Uzytkownicy WHERE TypKonta = @a";

            //login
            cmd.AddParameter("@a", 2);

            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Pracownik tempPracownik = new Pracownik();
                //id
                tempPracownik.id = reader.GetInt32(0);
                //email
                tempPracownik.email = reader.GetString(1);
                //haslo 
                tempPracownik.haslo = reader.GetString(2);
                //pesel 
                tempPracownik.pesel = reader.GetInt64(3);
                //imie 
                tempPracownik.imie = reader.GetString(4);
                //nazwisko 
                tempPracownik.nazwisko = reader.GetString(5);
                //adres 
                tempPracownik.adres = reader.GetString(6);
                //dataUrodzenia 
                tempPracownik.dataUrodzenia = reader.GetDateTime(7);
                //nrTelefonu 
                tempPracownik.nrTelefonu = reader.GetInt32(8);
                //typ 
                tempPracownik.typ = reader.GetInt16(9);
                employees.Add(tempPracownik);
            }
            reader.Close();
            return employees;

        }

        public static List<Klient> WyswietlWszystkicj() {

            List<Klient> all = new List<Klient>();
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "SELECT * FROM Uzytkownicy";

            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Klient tempUser = new Klient();
                //id
                tempUser.id = reader.GetInt32(0);
                //email
                tempUser.email = reader.GetString(1);
                //haslo 
                tempUser.haslo = reader.GetString(2);
                //pesel 
                tempUser.pesel = reader.GetInt64(3);
                //imie 
                tempUser.imie = reader.GetString(4);
                //nazwisko 
                tempUser.nazwisko = reader.GetString(5);
                //adres 
                tempUser.adres = reader.GetString(6);
                //dataUrodzenia 
                tempUser.dataUrodzenia = reader.GetDateTime(7);
                //nrTelefonu 
                tempUser.nrTelefonu = reader.GetInt32(8);
                //typ 
                tempUser.typ = reader.GetInt16(9);
                all.Add(tempUser);
            }
            reader.Close();
            return all;

        }
    }
}