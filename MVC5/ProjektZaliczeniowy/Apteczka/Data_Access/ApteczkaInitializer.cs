using Apteczka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apteczka.Data_Access
{
    public class ApteczkaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApteczkaContext>
    {
        protected override void Seed(ApteczkaContext context)
        {
            var apteczki = new List<ApteczkaModel>
            {
                new ApteczkaModel{Nazwa="Apteczka Gdańsk", DataUtworzenia=DateTime.Parse("13-06-2020")},
                new ApteczkaModel{Nazwa="Apteczka Gdynia", DataUtworzenia=DateTime.Parse("22-04-2020")},
                new ApteczkaModel{Nazwa="Apteczka Olsztyn", DataUtworzenia=DateTime.Parse("03-02-2020")}
            };

            apteczki.ForEach(apteczka => context.ApteczkiDB.Add(apteczka));
            context.SaveChanges();

            var leki = new List<LekModel>
            {
                new LekModel
                {
                    ApteczkaID=1,
                    Nazwa="neo-angin",
                    Kategoria=Kategoria.NaGardlo,
                    Forma=Forma.Tabletka,
                    Producent="Klosterfrau",
                    Ilosc=24,
                    TerminWaznosci=DateTime.Parse("02-2020")
                },
                new LekModel
                {
                    ApteczkaID=1,
                    Nazwa="Poltram Combo Forte",
                    Kategoria=Kategoria.Antybiotyk,
                    Forma=Forma.Tabletka,
                    Producent="Polpharma",
                    Ilosc=20,
                    TerminWaznosci=DateTime.Parse("03-2021")
                },
                new LekModel
                {
                    ApteczkaID=1,
                    Nazwa="Metronidazol",
                    Kategoria=Kategoria.Antybiotyk,
                    Forma=Forma.Tabletka,
                    Producent="Polpharma",
                    Ilosc=20,
                    TerminWaznosci=DateTime.Parse("04-2020")
                },
                new LekModel
                {
                    ApteczkaID=1,
                    Nazwa="Rutinoscorbin",
                    Kategoria=Kategoria.Suplement,
                    Forma=Forma.Tabletka,
                    Producent="GlaxoSmithKline",
                    Ilosc=30,
                    TerminWaznosci=DateTime.Parse("08-2022")
                },
                new LekModel
                {
                    ApteczkaID=2,
                    Nazwa="Rutinoscorbin",
                    Kategoria=Kategoria.Suplement,
                    Forma=Forma.Tabletka,
                    Producent="GlaxoSmithKline",
                    Ilosc=30,
                    TerminWaznosci=DateTime.Parse("08-2021")
                },
                new LekModel
                {
                    ApteczkaID=2,
                    Nazwa="Traumon",
                    Kategoria=Kategoria.Przeciwzapalny,
                    Forma=Forma.Masc,
                    Producent="Meda Aktiebolag",
                    Ilosc=50,
                    TerminWaznosci=DateTime.Parse("08-2023")
                },
                new LekModel
                {
                    ApteczkaID=3,
                    Nazwa="ALPA Francovka",
                    Kategoria=Kategoria.Inne,
                    Forma=Forma.Plyn,
                    Producent="ALPA",
                    Ilosc=160,
                    TerminWaznosci=DateTime.Parse("01-2021")
                },
                new LekModel
                {
                    ApteczkaID=3,
                    Nazwa="electroVit",
                    Kategoria=Kategoria.Suplement,
                    Forma=Forma.Tabletka,
                    Producent="ActivLab",
                    Ilosc=20,
                    TerminWaznosci=DateTime.Parse("14-03-2019")
                },
                new LekModel
                {
                    ApteczkaID=2,
                    Nazwa="Ibuprom",
                    Kategoria=Kategoria.Przeciwbolowy,
                    Forma=Forma.Tabletka,
                    Producent="Producent",
                    Ilosc=15,
                    TerminWaznosci=DateTime.Parse("05-2021")
                },
                new LekModel
                {
                    ApteczkaID=1,
                    Nazwa="electroVit",
                    Kategoria=Kategoria.Suplement,
                    Forma=Forma.Tabletka,
                    Producent="ActivLab",
                    Ilosc=20,
                    TerminWaznosci=DateTime.Parse("14-03-2019")
                },
                new LekModel
                {
                    ApteczkaID=1,
                    Nazwa="Ibuprom",
                    Kategoria=Kategoria.Przeciwbolowy,
                    Forma=Forma.Tabletka,
                    Producent="Producent",
                    Ilosc=15,
                    TerminWaznosci=DateTime.Parse("05-2021")
                },
                new LekModel
                {
                    ApteczkaID=1,
                    Nazwa="Apap",
                    Kategoria=Kategoria.Przeciwbolowy,
                    Forma=Forma.Tabletka,
                    Producent="Producent Apapu",
                    Ilosc=30,
                    TerminWaznosci=DateTime.Parse("02-2025")
                },
                new LekModel
                {
                    ApteczkaID=2,
                    Nazwa="Apap",
                    Kategoria=Kategoria.Przeciwbolowy,
                    Forma=Forma.Tabletka,
                    Producent="Producent Apapu",
                    Ilosc=30,
                    TerminWaznosci=DateTime.Parse("02-2025")
                },
                new LekModel
                {
                    ApteczkaID=3,
                    Nazwa="Apap",
                    Kategoria=Kategoria.Przeciwbolowy,
                    Forma=Forma.Tabletka,
                    Producent="Producent Apapu",
                    Ilosc=30,
                    TerminWaznosci=DateTime.Parse("02-2025")
                },
            };
            leki.ForEach(lek => context.LekiDB.Add(lek));
            context.SaveChanges();
        }
    }
}