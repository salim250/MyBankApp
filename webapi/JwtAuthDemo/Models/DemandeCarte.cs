using System;

namespace JwtAuthDemo.Models
{
    public class DemandeCarte
    {
        public int Id { get; set; }
        public DateTime dateDemande { get; set; }
        public string type { get; set; }
        public string etat { get; set; }
        public Client client { get; set; }
    }
}
