using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Apteczka.Models
{
    public enum Kategoria { Antybiotyk, Przeciwzapalny, Przeciwbolowy, NaKaszel, NaKatar, NaGardlo, Suplement, Inne }
    public enum Forma { Tabletka, Syrop, Plyn, Proszek, Krem, Masc, Inna }
    public class LekModel
    {
        public int ID { get; set; }
        public int ApteczkaID { get; set; }
        [Required]
        [StringLength(150)]
        public string Nazwa { get; set; }
        [Required]
        public Kategoria? Kategoria { get; set; }
        [Required]
        public Forma? Forma { get; set; }
        [StringLength(100)]
        public string Producent { get; set; }
        [Required]
        public double Ilosc { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime TerminWaznosci { get; set; }

        public virtual ApteczkaModel Apteczka { get; set; }
    }
}