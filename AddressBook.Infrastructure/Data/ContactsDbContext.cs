using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AddressBook.Data
{
    public class ContactsDbContext
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionstring;

        private readonly IDbConnection _connection;

        public ContactsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionstring);
        }

        public IDbConnection connection { get { return _connection; } }
    }
}