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
    public class MongoCategory : MongoBase<Category>
    {
        public MongoCategory()
            : base("category")
        {

        }

        public ResultStatus Remove(int id)
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var query = Query<Category>.EQ(e => e.CategoryId, id);
                var collection = conn.DataBase.GetCollection<Category>(NameCollection);
                var writeResult = collection.Remove(query);
                var result = new ResultStatus
                {
                    Status = writeResult.Ok ? StatusOperation.Success : StatusOperation.Error,
                    Created = 0,
                    Updated = 0,
                    Removed = writeResult.Response[0].AsInt32,
                    Message = writeResult.Ok ? "Success" : writeResult.ErrorMessage
                };
                return result;
            }
        }

        public BaseEntity GetOne(int id)
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var collection = conn.DataBase.GetCollection<Category>(NameCollection);
                var query = Query<Category>.EQ(e => e.CategoryId, id);
                var entity = collection.FindOne(query);
                return entity;
            }
        }

        public Category GetOne(string name)
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var collection = conn.DataBase.GetCollection<Category>(NameCollection);
                var query = Query<Category>.EQ(e => e.Name, name);
                var entity = collection.FindOne(query);
                return entity;
            }
        }
        public ResultStatus Update(Category item, Category newItem)
        {
            using (var conn = new MongoConnection(ConnectionString, Database))
            {
                var collection = conn.DataBase.GetCollection<Category>(NameCollection);
                var query = Query<Category>.EQ(e => e.CategoryId, item.CategoryId);
                var entity = collection.FindOne(query);
                var id = entity.Id;
                entity = newItem;
                entity.Id = id;
                var writeResult = collection.Save(entity);
                var result = new ResultStatus
                {
                    Status = writeResult.Ok ? StatusOperation.Success : StatusOperation.Error,
                    Created = 0,
                    Updated = writeResult.Response[0].AsInt32,
                    Removed = 0,
                    Message = writeResult.Ok ? "Success" : writeResult.ErrorMessage
                };
                return result;
            }
        }
    }
}
