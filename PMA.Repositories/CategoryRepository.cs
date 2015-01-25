using PMA.DataAccess.MongoDB;
using PMA.Entities;
using PMA.Helpers;
using PMA.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace PMA.Repositories
{
    public class CategoryRepository
    {
        MongoCategory mongoCategory = null;

        public CategoryRepository()
        {
            mongoCategory = new MongoCategory();
        }

        public ResultStatus CreateCategory(Category category)
        {
            if (!IsExistCategory(category))
            {
                var result = mongoCategory.Insert(category);
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
                    Message = "This category is exist. Please check the name of this category."
                };
            }
        }

        public ResultStatus UpdateCategory(Category category, Category newCategory)
        {
            var result = mongoCategory.Update(category, newCategory);
            return result;
        }

        public ResultStatus RemoveCategory(Category category)
        {
            var result = mongoCategory.Remove(category.CategoryId);
            return result;
        }

        public IQueryable<Category> GetCategories()
        {
            var categories = mongoCategory.GetCollection().AsQueryable();
            return categories;
        }

        public IQueryable<Category> GetCategories(int parentId)
        {
            var categories = mongoCategory.GetCollection().AsQueryable().Where(x => x.ParentCategoryId == parentId);
            return categories;
        }

        public Category GetCategory(int categoryId)
        {
            var category = mongoCategory.GetOne(categoryId) as Category;
            return category;
        }

        public Category GetCategory(string nameCategory)
        {
            var category = mongoCategory.GetOne(nameCategory) as Category;
            return category;
        }

        private bool IsExistCategory(Category category)
        {
            var existCategory = mongoCategory.GetOne(category.Name);
            return existCategory == null ? false : true;
        }
    }
}
