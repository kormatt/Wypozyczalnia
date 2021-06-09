using Projekcior.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekcior.Controllers
{
    public class EmplController : Controller, Ilogger<MvcApplication>
    {      
        // GET: Empl
        
        public ActionResult EditClients() {
            //if ((int)Session["Type"] < 3) {
                return View(Pracownik.WyswietlKlientow());
            //}
            //return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult EditClient(Klient Client) {
            Pracownik.EdytujKlienta(Client);
            this.GetLog().Info("Customer("+ Client.imie +" "+ Client.nazwisko + ") detail have been changed");
            //return Content(empl.id + " " + empl.email + " " + empl.haslo + " " + empl.Type);
            return RedirectToAction("EditClients");
        }

        [HttpPost]
        public ActionResult AddClient(Klient Client) {
            Pracownik.DodajKlienta(Client);
            this.GetLog().Info("Customer(" + Client.imie + " " + Client.nazwisko + ") detail have been added");
            //return Content(empl.id + " " + empl.email + " " + empl.haslo + " " + empl.Type);
            return RedirectToAction("EditClients");
        }

        [HttpPost]
        public ActionResult DeleteClient(Klient Client) {
            Pracownik.UsunKlienta(Client);
            this.GetLog().Warn("Customer(" + Client.imie + " " + Client.nazwisko + ") has been deleted");
            //return Content(empl.id + " " + empl.email + " " + empl.haslo + " " + empl.Type);
            return RedirectToAction("EditClients");
        }

        public ActionResult ShowCars() {
            MultipleList multiple = new MultipleList();
            multiple.Brands = Pracownik.WyswietlMarki();
            multiple.Cars = Pracownik.WyswietlSamochody();
            return View(multiple);
        }

        public ActionResult ShowRentals() {
            MultipleList2 multiple = new MultipleList2();
            multiple.Brands = Pracownik.WyswietlMarki();
            multiple.Cars = Pracownik.WyswietlSamochody();
            multiple.Clients = Szef.WyswietlWszystkicj();
            multiple.Rentals = Pracownik.PokazRezerwacje();
            
            return View(multiple);
        }
        
        [HttpPost]
        public ActionResult EditRental(Rezerwacja res) {
            Pracownik.EdytujRezerwacje(res);
            this.GetLog().Info("Reservation no." + res.id + " has been edited");
            return RedirectToAction("ShowRentals");            
            
        }
        
        [HttpPost]
        public ActionResult DeleteRental(Rezerwacja res) {
            Pracownik.UsunRezerwacje(res);
            this.GetLog().Warn("Reservation no." + res.id + " has been deleted");
            return Content(res.dataRozpoczecia.ToString());
        }

        [HttpPost]
        public ActionResult AddRental(Rezerwacja res) {
            Pracownik.DodajRezerwacje(res);
            this.GetLog().Info("Reservation no." + res.id + " has been added");
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult EditCar(Samochod car) {
            Pracownik.EdytujSamochod(car);
            this.GetLog().Info("Car with a registration no." + car.nrTablicyRej + " has been edited");
            return RedirectToAction("ShowCars");
           
        }

        [HttpPost]
        public ActionResult DeleteCar(Samochod car) {
            Pracownik.UsunSamochod(car);
            this.GetLog().Warn("Car with a registration no." + car.nrTablicyRej + " has been deleted");
            return RedirectToAction("ShowCars");

        }        
        [HttpPost]
        public ActionResult AddCar(Samochod car) {
            Pracownik.DodajSamochod(car);
            this.GetLog().Info("Car with a registration no." + car.nrTablicyRej + " has been added");
            //return Content(car.dostepny.ToString());
            return RedirectToAction("ShowCars");

        }
    }
}