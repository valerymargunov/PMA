using MongoDB.Bson;
using PMA.DataAccess.MongoDB;
using PMA.Entities;
using PMA.Helpers;
using PMA.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Repositories
{
    public class ProductRepository
    {
        MongoProduct mongoProduct = null;

        public ProductRepository()
        {
            mongoProduct = new MongoProduct();
        }

        public ResultStatus CreateProduct(Product product)
        {
            if (!IsExistProduct(product))
            {
                var result = mongoProduct.Insert(product);
                return result;
            }
            else
            {
                return new ResultStatus
                {
                    Created = 0,
                    Updated = 0,
                    Removed = 0,
                    Status = StatusOperation.Error,
                    Message = "This product is exist. Please check the name of this product."
                };
            }
        }

        public ResultStatus UpdateProduct(Product product, Product newProduct)
        {
            var result = mongoProduct.Update(product, newProduct);
            return result;
        }

        public ResultStatus RemoveProduct(Product product)
        {
            var result = mongoProduct.Remove(product.ProductId);
            return result;
        }

        public IQueryable<Product> GetProducts()
        {
            var products = mongoProduct.GetCollection().AsQueryable();
            return products;
        }

        public IQueryable<Product> GetProducts(int categoryId)
        {
            var products = mongoProduct.GetCollection().AsQueryable().Where(x => x.ProductId == categoryId);
            return products;
        }

        public Product GetProduct(int ProductId)
        {
            var Product = mongoProduct.GetOne(ProductId) as Product;
            return Product;
        }

        public Product GetProduct(string nameProduct)
        {
            var Product = mongoProduct.GetOne(nameProduct) as Product;
            return Product;
        }

        private bool IsExistProduct(Product product)
        {
            var existProduct = mongoProduct.GetOne(product.Name);
            return existProduct == null ? false : true;
        }
    }
}
