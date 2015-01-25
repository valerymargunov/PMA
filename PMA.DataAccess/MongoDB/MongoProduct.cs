using MongoDB.Driver.Builders;
using PMA.Entities;
using PMA.Helpers;
using PMA.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.DataAccess.MongoDB
{
    public class MongoProduct : MongoBase<Product>
    {
        public MongoProduct()
            : base("product")
        {

        }

        //public bool Remove(string name)
        //{
        //    using (var conn = new MongoConnection(ConnectionString, Database))
        //    {
        //        var query = Query<Product>.EQ(e => e.Name, name);
        //        var collection = conn.DataBase.GetCollection<Product>(NameCollection);
        //        return collection.Remove(query).Ok;
        //    }
        //}

        public ResultStatus Remove(int id)
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var query = Query<Product>.EQ(e => e.ProductId, id);
                var collection = conn.DataBase.GetCollection<Product>(NameCollection);
                var writeResult = collection.Remove(query);
                var result = new ResultStatus
                {
                    Status = writeResult.Ok ? StatusOperation.Success : StatusOperation.Error,
                    Created = 0,
                    Updated = 0,
                    Removed = writeResult.Response.AsInt32,
                    Message = writeResult.Ok ? "Success" : writeResult.ErrorMessage
                };
                return result;
            }
        }

        public BaseEntity GetOne(int id)
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var collection = conn.DataBase.GetCollection<Product>(NameCollection);
                var query = Query<Product>.EQ(e => e.ProductId, id);
                var entity = collection.FindOne(query);
                return entity;
            }
        }

        public Product GetOne(string name)
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var collection = conn.DataBase.GetCollection<Product>(NameCollection);
                var query = Query<Product>.EQ(e => e.Name, name);
                var entity = collection.FindOne(query);
                return entity;
            }
        }

        public ResultStatus Update(Product item, Product newItem)
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var collection = conn.DataBase.GetCollection<Product>(NameCollection);
                var query = Query<Product>.EQ(e => e.ProductId, item.ProductId);
                var entity = collection.FindOne(query);
                var id = entity.Id;
                entity = newItem;
                entity.Id = id;
                var writeResult = collection.Save(entity);
                var result = new ResultStatus
                {
                    Status = writeResult.Ok ? StatusOperation.Success : StatusOperation.Error,
                    Created = 0,
                    Updated = writeResult.Response.AsInt32,
                    Removed = 0,
                    Message = writeResult.Ok ? "Success" : writeResult.ErrorMessage
                };
                return result;
            }
        }
    }
}
