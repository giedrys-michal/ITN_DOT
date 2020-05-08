using MVC_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MVC_v1.Controllers
{
    public class AukcjeController : Controller
    {
        // GET: Aukcje

        public ActionResult Index(string nazwa)
        {
            List<Aukcja> aukcje = new List<Aukcja>()
            {
                new Aukcja("Latarka", 12.99m, "Zawisza Czarny", 14),
                new Aukcja("Mlotek", 8, "Janusz", 7),
                new Aukcja("Lampka", 94.99m, "Mirek", 7),
            };

            aukcje[1].status = Status.anulowana;
            aukcje[2].ceny.Add(120);
            aukcje[2].ceny.Add(130);
            aukcje[2].ceny.Add(150);
            aukcje[2].ceny.Add(180);


            // na niepustej kolekcji wywal aukcje których nazwa zawiera to co w filtrze
            if (!String.IsNullOrEmpty(nazwa))
                for (int i = 0; i < aukcje.Count; i++)
                    if (!aukcje[i].przedmiot.Contains(nazwa))
                        aukcje.RemoveAt(i--);

            return View(aukcje);
        }
    }
}