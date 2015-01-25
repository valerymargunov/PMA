using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.DataAccess.MongoDB
{
    public class MongoConnection : IDisposable
    {

        public MongoDatabase DataBase = null;

        public MongoConnection(string connectionString, string database)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            this.DataBase = server.GetDatabase(database);
        }

        public void Dispose()
        {
            this.DataBase.Server.Disconnect();
        }
    }
}
