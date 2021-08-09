using ProjetoAspNetMVC02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC02.Interfaces
{
    public  interface IClientRepository
    {
        void Insert(Client client);        
        void Delete(Client client);
        void Alter(Client client);
        List<Client> Consult();
        List<Client> ConsultByName(string name);
        Client GetByID(Guid clientId);
    }
}
