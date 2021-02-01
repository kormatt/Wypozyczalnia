using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;


namespace Projekcior.Models
{
    public class Klient : IAccommodatable {

        //wszystkie klasy na public
        public int id { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public long pesel { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string adres { get; set; }
        public DateTime dataUrodzenia { get; set; }
        public int nrTelefonu { get; set; }
        public int typ { get; set; }
        //that does not exist in db
        public string daneOsobowe { get; set; }   
        
        //public string Login { get; set; }
        //public string Passwd { get; set; }

        public bool Zaloguj()
        {
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "SELECT TypKonta FROM Uzytkownicy WHERE email = @a AND haslo = @b";

            //login
            cmd.AddParameter("@a", email);
            //passwd
            cmd.AddParameter("@b", haslo);

            bool Veryfied = System.Convert.ToBoolean(cmd.ExecuteScalar());

            if (Veryfied) {
                typ = (int)cmd.ExecuteScalar();
            }
            return Veryfied;

        }

        public int getid() {
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            //temp solution, to replace with custom sql function
            cmd.CommandText = "SELECT idUzytkownika FROM Uzytkownicy WHERE email = @a AND haslo = @b";

            //login
            cmd.AddParameter("@a", email);
            //passwd
            cmd.AddParameter("@b", haslo);

            return (int)cmd.ExecuteScalar();

        }
        public bool ZarejestrujKlienta()
        {
            var con = Database.GetConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Uzytkownicy WHERE email = @a";

            cmd.AddParameter("@a", email);
            bool Busy = System.Convert.ToBoolean(cmd.ExecuteScalar());
            if (!Busy)
            {
                cmd.CommandText = "INSERT INTO Uzytkownicy(email, haslo, pesel, imie, nazwisko, adres, dataUrodzenia, nrTelefonu, TypKonta) " +
                    "VALUES (@a, @b, @c, @d, @e, @f, @g, @h, @i)";

                cmd.AddParameter("@b", haslo);
                cmd.AddParameter("@c", pesel);
                cmd.AddParameter("@d", imie);
                cmd.AddParameter("@e", nazwisko);
                cmd.AddParameter("@f", adres);
                cmd.AddParameter("@g", dataUrodzenia.ToString("yyyy-MM-dd"));
                cmd.AddParameter("@h", nrTelefonu);
                cmd.AddParameter("@i", typ);

                cmd.ExecuteScalar();
                return true;
            }
            else
            {
                return false; ;
            }
        }


        //public void Wyloguj() { }
        public void ZmienDane() { }
        //public xRezerwacja Zarezerwuj(int idSamochodu, int idKlienta) { }


        public static bool ValidateEmail(String email) {
            Regex emailRegex = new Regex(@"^(?<email>.+\@.+\.\w+)");
            var emailMatches = emailRegex.Matches(email);
            return emailMatches.Equals(0) ? false : true;
        }

        public static bool ValidatePassword(String password)
        {
            Regex passwordRegex = new Regex(@"^(?<haslo>.{8}.*)");
            var passwordMatches = passwordRegex.Matches(password);
            return passwordMatches.Equals(0) ? false : true;
        }

        //public static bool gags()
        //{
        //    Regex addressRegex = new Regex(@" ^ (?<email>.+\@.+\.\w+)\s+(?<haslo>.{8}.*)\s+(?<imie>[A-ZŻĄŃĆŁÓŚ]{1}[a-zżńąćłóś]+)\s+(?<nazwisko>[A-ZŻĄŃĆŁÓŚ]{1}[a-zżńąćłóś]+)\s+(?<adres>.+)\b", RegexOptions.Compiled);
        //    var matches = addressRegex.Matches(text);
        //    if (matches.Equals(0))
        //    {
        //        return;
        //    }
        //    foreach (Match match in matches)
        //    {
        //        var groups = match.Groups;
        //        email = groups["email"].Value;
        //        haslo = groups["haslo"].Value;
        //        imie = groups["imie"].Value;
        //        nazwisko = groups["nazwisko"].Value;
        //        adres = groups["adres"].Value;
        //    }
        //}

        public void AccommodateLong(long nrpesel) {
            Regex addressRegex = new Regex(@"^(?<pesel>\d{11})\b", RegexOptions.Compiled);
            var matches = addressRegex.Matches(nrpesel.ToString());
            foreach (Match match in matches) {
                var groups = match.Groups;
                pesel = long.Parse(groups["pesel"].Value);

            }
        }

        public void AccommodateInt(int number) {
            Regex addressRegex = new Regex(@"^(?<nrTelefonu>\d{9})\b", RegexOptions.Compiled);
            var matches = addressRegex.Matches(number.ToString());
            foreach (Match match in matches) {
                var groups = match.Groups;
                nrTelefonu = int.Parse(groups["nrTelefonu"].Value);

            }
        }

        //public xRezerwacja Zarezerwuj(int idSamochodu, int idKlienta) { }
    }
}
