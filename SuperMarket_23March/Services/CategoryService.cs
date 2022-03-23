using SuperMarket_23March.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket_23March.Services
{

    public class CategoryService : IService<Category, int>
    {
        SuperMarketContext ctx;
        public CategoryService(SuperMarketContext c)  
        {
            ctx = c;
        }
        bool IService<Category, int>.Create(Category entity)
        {
            int res = 0;
            bool isSuccess = false;
            ctx.Categories.Add(entity);
            res = ctx.SaveChanges();
            if (res >= 0)
            {
                isSuccess = true;
            }
            return isSuccess;
        }

        bool IService<Category, int>.Delete(int id)
        {
            bool isSuccess = false;
            var cat = ctx.Categories.Find(id);
            if (cat != null)
            {
                ctx.Categories.Remove(cat);
                ctx.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        IEnumerable<Category> IService<Category, int>.Get()
        {
            var cats = ctx.Categories.ToList();
            return cats;
        }

        Category IService<Category, int>.Get(int id)
        {
            var cat = ctx.Categories.Find(id);
            return cat;
        }

        bool IService<Category, int>.Update(int id, Category entity)
        {
            bool isSuccess = false;
            var cat = ctx.Categories.Find(id);
            if (cat != null)
            {
                cat.CategoryName = entity.CategoryName;
                ctx.SaveChanges();
            }
            return isSuccess;
        }
    }
}
