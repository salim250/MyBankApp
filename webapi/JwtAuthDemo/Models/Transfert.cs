using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JwtAuthDemo.Models
{
    public class Transfert
    {
        public int Id { get; set; }
        public int montant { get; set; }
        public DateTime date { get; set; }
        
        
        public Client clientDebiteur { get; set; }
        public Client clientRecepteur { get; set; }
    }
}
