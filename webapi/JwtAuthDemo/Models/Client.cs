using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JwtAuthDemo.Models
{
    [Table("Client")]
    
    public partial class Client:User
    {
        
        public int NumeroCompte { get; set; }
        public int cin { get; set; }
        public ICollection<DemandeChequier> demandeChequier { get; set; }
        public ICollection<DemandeCarte> demandeCarte { get; set; }
        public int solde { get; set; }
        [JsonIgnore]
        public ICollection<Solde> extrait { get; set; }
        [InverseProperty("clientDebiteur")]
        
        public ICollection<Transfert> transfertDebiteur { get; set; }
        
        [InverseProperty("clientRecepteur")]
        public ICollection<Transfert> transfertRecepteur { get; set; }

        
    }
}
