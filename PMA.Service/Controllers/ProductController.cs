using PMA.Entities;
using PMA.Helpers.Enums;
using PMA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMA.Service.Controllers
{
    public class ProductController : ApiController
    {
        ProductRepository productRepository = null;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        // GET api/product
        public IEnumerable<Product> GetProducts()
        {
            var products = productRepository.GetProducts();
            return products;
        }

        // GET api/product/5
        public Product GetProduct(int id)
        {
            var product = productRepository.GetProduct(id);
            if (product == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return product;
        }

        // POST api/product
        public HttpResponseMessage PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.CreateProduct(product);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/product/5
        public HttpResponseMessage PutProduct(int id, Product product)
        {
            if (ModelState.IsValid && id == product.ProductId)
            {
                var currentProduct = productRepository.GetProduct(id);
                if (currentProduct == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                var result = productRepository.UpdateProduct(currentProduct, product);
                if (result.Status == StatusOperation.Error)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/product/5
        public HttpResponseMessage DeleteProduct(int id)
        {
            var product = productRepository.GetProduct(id);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                productRepository.RemoveProduct(product);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
