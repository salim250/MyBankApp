using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthDemo.Models
{
    public class DemandeChequier
    {
        public int Id { get; set; }
        public DateTime dateDemande { get; set; }
        public int nombre { get; set; }
        public string etat { get; set; }
        public Client client { get; set; }

    }
}
