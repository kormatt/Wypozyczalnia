using Projekcior.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekcior.Controllers {
    public class HomeController : Controller, Ilogger<MvcApplication> {
        static string activePage;
        public ActionResult Index() {
            activePage = "Index";
            this.GetLog().Debug("Accessing home page of the application");
            return View();
        }

        public ActionResult About() {       
            activePage = "About";
            return View();
        }

        public ActionResult Contact() {
            activePage = "Contact";
            return View();
        }
        public ActionResult Login() {
            if (Session["Email"] != null)
                return RedirectToAction("LoggedIndex");
            if (activePage == "testlogin")
                ModelState.AddModelError("LoginError", "Podano nieprawidłowe Dane logowania, prosze podać poprawne ");
            return View();
        }

        public ActionResult LoggedIndex() {
            activePage = "LoggedIndex";
           // if (Session["Email"] != null)
                return View();
            //else
            //   return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult testlogin(Klient klient) {
            activePage = "testlogin";
            if (klient.Zaloguj())
            {
                Session["Email"] = klient.email;
                Session["Type"] = klient.typ;
                this.GetLog().Info("Client " + klient.email + " has logged into application");
                return RedirectToAction("LoggedIndex");
                //return Content(Session["Type"].ToString());
            }
            else
            {
                this.GetLog().Warn("Client " + klient.email + " has not logged into application");
                return RedirectToAction("Login");
            }
        }
        public ActionResult logout() {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult RegisterForm()
        {
            return View();
        }

        public ActionResult testRegister(Klient klient)
        {
            activePage = "testRegister";
            if (klient.ZarejestrujKlienta())
            {
                Session["Email"] = klient.email;
                Session["Type"] = 3;
                Session["ID"] = klient.getid();
                this.GetLog().Info("Client " + klient.imie + " " + klient.nazwisko + " created an account");
                return RedirectToAction("LoggedIndex");
            }
            else
            {

                this.GetLog().Warn("Excisting client with email: " + klient.email + " wanted create new account");
                return RedirectToAction("RegisterForm");
            }
        }

        public ActionResult EditAccount() {

            return View( Pracownik.WyswietlKlienta( (int)Session["ID"] ) );
            //return View( Pracownik.WyswietlKlienta( 10 ) );
        }
        public ActionResult EditMe(Klient klient) {
            klient.typ = (int)Session["Type"];

            Pracownik.EdytujKlienta(klient);
            return RedirectToAction("LoggedIndex");
        }
        public ActionResult ShowRental(Klient klient) {
            
            MultipleList2 multiple = new MultipleList2();
            multiple.Brands = Pracownik.WyswietlMarki();
            multiple.Cars = Pracownik.WyswietlSamochody();
            multiple.Clients = Szef.WyswietlWszystkicj();
            multiple.Rentals = Pracownik.PokazRezerwacje((int)Session["ID"]));

            return View(multiple);
        }
        [HttpPost]
        public ActionResult AddRental(Rezerwacja res) {
            Pracownik.DodajRezerwacje(res);
            this.GetLog().Info("Reservation no." + res.id + " has been added");
            return RedirectToAction("ShowRental");
        }
    }
}