using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFramework.Models
{
    public class OperyDB : DbContext
    {
        public DbSet<Opera> Opery { get; set; }
    }
    public class Opera
    {
        public int OperaID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nazwa { get; set; }
        public int Rok { get; set; }

        [Required]
        [StringLength(150)]
        public string Kompozytor { get; set; }
        public string Dlugosc { get; set; }

    }
}