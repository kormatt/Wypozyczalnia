using Projekcior.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekcior.Controllers
{
    public class BossController : Controller,  Ilogger<MvcApplication>
    {
        // GET: Boss
        public ActionResult EditEmployees()
        {
            //if((int)Session["Type"] == 1) {
                    return View(Szef.WyswietlPracownikow());
            //}
            //return RedirectToAction("Index", "Home");
            
        }
        [HttpPost]
        public ActionResult AddEmployee(Pracownik empl) {
            Szef.DodajPracownika(empl);
            this.GetLog().Info("Emlpoyee " + empl.imie +" " + empl.imie + " has been added");
            return RedirectToAction("EditEmployees");
            //return Content(empl.email + " " + empl.haslo);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(Pracownik empl) {
            Szef.UsunPracownika(empl);
            this.GetLog().Warn("Emlpoyee " + empl.imie + " " + empl.imie + " has been deleted");
            //return Content(empl.id + " " + empl.email + " " + empl.haslo + " " + empl.typ);
            return RedirectToAction("EditEmployees");
        }


        [HttpPost]
        public ActionResult EditEmployee(Pracownik empl) {
            Szef.EdytujPracownika(empl);
            this.GetLog().Info("Emlpoyee " + empl.imie + " " + empl.imie + " has been edited");
            //return Content(empl.id + " " + empl.email + " " + empl.haslo + " " + empl.Type);
            return RedirectToAction("EditEmployees");
        }
    }
}