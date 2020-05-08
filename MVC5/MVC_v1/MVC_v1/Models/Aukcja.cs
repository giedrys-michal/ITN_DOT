using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_v1.Models
{
    public enum Status { aktywna, wstrzymana, anulowana, oczekuje };
    public class Aukcja
    {
        public static int liczbaAukcji;
        public int aukcjaID { get; set; }
        public string przedmiot { get; set; }
        public decimal cenaWywolawcza { get; set; }
        public List<decimal> ceny = new List<decimal>();
        public Status status { get; set; }
        public DateTime dataStart { get; set; }
        public DateTime dataZakonczenia { get; set; }
        public string sprzedajacy { get; set; }

        public Aukcja(string przedmiot, decimal cenaWywolawcza, string sprzedajacy, double czasTrwania)
        {
            this.aukcjaID = ++liczbaAukcji;
            this.przedmiot = przedmiot;
            this.cenaWywolawcza = cenaWywolawcza;
            this.dataStart = DateTime.Now;
            this.dataZakonczenia = DateTime.Now.AddDays(czasTrwania);
            this.status = Status.aktywna;
            this.sprzedajacy = sprzedajacy;
        }
    }
}