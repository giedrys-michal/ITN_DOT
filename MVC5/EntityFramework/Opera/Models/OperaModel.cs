using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Opera.Models
{
    public class OperyDB : DbContext
    {
        public DbSet<OperaModel> Opery { get; set; }
    }
    public class OperaModel
    {
        public int OperaModelID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nazwa { get; set; }
        public int Rok { get; set; }

        [Required]
        [StringLength(150)]
        public string Kompozytor { get; set; }
        public string Dlugosc { get; set; }
    }

    public class SprawdzRok : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int rok = (int)value;
            int biezacyRok = DateTime.Now.Year;

            if (rok < 1598 || rok > biezacyRok)
            {
                return false;
            }
            else
                return true;
        }

        public SprawdzRok()
        {
            ErrorMessage = "Przed rokiem 1598 nie skomponowano żadnej opery!";
        }
    }
}