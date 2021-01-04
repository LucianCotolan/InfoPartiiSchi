using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InfoPartiiSchi.Models
{
    public class Partie
    {
        public int ID { get; set; }
        public string Nume { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Lungime { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal AltitudineMaxima { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal AltitudineMinima { get; set; }

        public string Dificultate { get; set; }

        public string Video { get; set; }

        public int StatiuneID { get; set; }
        public Statiune Statiune { get; set; }
    }
}
