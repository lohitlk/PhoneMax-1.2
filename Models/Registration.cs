using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneMax_1._1.Models
{
    public class Registration
    {
        public int Id { get; set; }

        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }
    }
}
