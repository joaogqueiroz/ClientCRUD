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
            var query = @"
                        UPDATE CLIENT 
                        SET
                            NAME = @Name,
                            EMAIL = @Email
                        WHERE  
                            CLIENTID = @ClientID
                        ";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, client);
            }
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

        public List<Client> ConsultByName(string name)
        {
            var query = @"
                        SELECT * FROM CLIENT
                        WHERE NAME LIKE @name
                        ";
            name = $"%{name}%";
            using (var connection = new SqlConnection(_connectionString))
            {
               return connection.Query<Client>(query, new { name }).ToList();
            }
        }

        public void Delete(Client client)
        {
            var query = @"
                        DELETE FROM CLIENT
                        WHERE CLIENTID =  @ClientID
                        ";
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Execute(query, client);
            }
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
                return connection.Query<Client>(query, new { clientId }).FirstOrDefault();
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
