using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apteczka.Models
{
    public class ApteczkaModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Nazwa { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataUtworzenia { get; set; }

        public virtual ICollection<LekModel> Leki { get; set; }
    }
}