using PMA.DataAccess;
using PMA.DataAccess.MongoDB;
using PMA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoBase<Product> mongoProduct = new MongoProduct();
            
            //var product = new Product()
            //{
            //    Name = "name"
            //};
            //var newProduct = new Product()
            //{
            //    //Name = "name2",
            //    Description = "description2",
            //    CategoryId = 11,
            //    Cost = 21,
            //    Amount = 31
            //};
            //var deleted = mongoProduct.Remove(newProduct.Name);
            //var inserted = mongoProduct.Insert(newProduct);
            //var result = mongoProduct.Update(product, newProduct);
            var result = mongoProduct.GetCollection();
        }
    }
}
