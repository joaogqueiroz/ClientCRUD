using Dapper;
using ProjetoAspNetMVC02.Entities;
using ProjetoAspNetMVC02.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC02.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private string _connectionString;

        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Alter(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Client> Consult()
        {
            var query = @"
                        SELECT * FROM CLIENT
                        ORDER BY NAME
                        ";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Client>(query).ToList();
            }
        }

        public void Delete(Client client)
        {
            throw new NotImplementedException();
        }

        public Client GetByID(Guid clientId)
        {
            var query = @"
                        SELECT * FROM CLIENT
                        WHERE
                        CLIENTID = @clientId
                        ";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query(query, clientId).FirstOrDefault();
            }
        }

        public void Insert(Client client)
        {
            var query = @"
                        INSERT INTO CLIENT(
                            CLIENTID,
                            NAME,
                            EMAIL,
                            REGISTRATIONDATA)
                        VALUES(
                            NEWID(),
                            @Name,
                            @Email,
                            GETDATE())
                        ";
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, client);
            }
        }
    }
}
