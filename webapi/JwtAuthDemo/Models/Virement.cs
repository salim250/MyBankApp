using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthDemo.Models
{
    public class Virement
    {
        public int Id { get; set; }
        public int compteDebiteur { get; set; }
        public int compteACrediter { get; set; }
        public int montant { get; set; }
        public string motif { get; set; }
    }
}
