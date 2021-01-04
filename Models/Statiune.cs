using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoPartiiSchi.Models
{
    public class Statiune
    {
        public int ID { get; set; }
        public string Nume { get; set; }

        [Display(Name = "Județ")]
        public string Judet { get; set; }
        public ICollection<Partie> Partii { get; set; }
    }
}
