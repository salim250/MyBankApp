using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace JwtAuthDemo.Models
{
    public class Solde
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string operation { get; set; }
        public int montantRetire { get; set; }
        public int montantVerse { get; set; }
        
        public Client client { get; set; }
    }
}
