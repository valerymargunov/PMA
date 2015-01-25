using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using PMA.DataAccess.MongoDB;
using PMA.Entities;
using PMA.Helpers;
using PMA.Helpers.Enums;

namespace PMA.DataAccess
{
    public class MongoBase<TEntity>
    {
        protected readonly string ConnectionString = "mongodb://localhost";
        protected readonly string Database = "pmadbtest";
        protected string NameCollection = String.Empty;

        public MongoBase(string nameCollection)
        {
            this.NameCollection = nameCollection;
        }

        public IQueryable<TEntity> GetCollection()
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var collection = conn.DataBase.GetCollection<TEntity>(NameCollection);
                return collection.AsQueryable();
            }
        }

        public ResultStatus Insert(TEntity item)
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var collection = conn.DataBase.GetCollection<TEntity>(NameCollection);

                var writeResult = collection.Insert<TEntity>(item);
                var result = new ResultStatus
                {
                    Status = writeResult.Ok ? StatusOperation.Success : StatusOperation.Error,
                    Created = writeResult.Response[0].AsInt32,
                    Updated = 0,
                    Removed = 0,
                    Message = writeResult.Ok ? "Success" : writeResult.ErrorMessage
                };
                return result;
            }
        }       
    }
}
