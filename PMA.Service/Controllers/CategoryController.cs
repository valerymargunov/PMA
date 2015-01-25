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
    public class CategoryController : ApiController
    {
        CategoryRepository categoryRepository = null;

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        // GET api/category
        public IEnumerable<Category> GetCategories()
        {
            var categories = categoryRepository.GetCategories();
            return categories;
        }

        // GET api/category/5
        public Category GetCategory(int id)
        {
            var category = categoryRepository.GetCategory(id);
            if (category == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return category;
        }

        // POST api/category
        public HttpResponseMessage PostCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.CreateCategory(category);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/category/5
        public HttpResponseMessage PutCategory(int id, Category category)
        {
            if (ModelState.IsValid && id == category.CategoryId)
            {
                var currentCategory = categoryRepository.GetCategory(id);
                if (currentCategory == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                var result = categoryRepository.UpdateCategory(currentCategory, category);
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

        // DELETE api/category/5
        public HttpResponseMessage DeleteCategory(int id)
        {
            var category = categoryRepository.GetCategory(id);
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                categoryRepository.RemoveCategory(category);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
