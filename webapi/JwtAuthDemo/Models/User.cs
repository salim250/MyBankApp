using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String password { get; set; }

        public Role role { get; set; }
        public String Email { get; set; }
    }
}
