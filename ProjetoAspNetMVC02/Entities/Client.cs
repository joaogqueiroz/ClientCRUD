using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC02.Entities
{
    public class Client
    {
        public Guid ClientID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationData { get; set; }

    }
}
