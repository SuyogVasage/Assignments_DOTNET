using SuperMarket_23March.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket_23March.Services
{
    public class ProductService : IService<Product, int>
    {
        SuperMarketContext ctx;
        public ProductService(SuperMarketContext c)
        {
            ctx = c;
        }
        bool IService<Product, int>.Create(Product entity)
        {
            int res = 0;
            bool isSuccess = false;
            ctx.Products.Add(entity);
            res = ctx.SaveChanges();
            if (res >= 0)
            {
                isSuccess = true;
            }
            return isSuccess;
        }

        bool IService<Product, int>.Delete(int id)
        {
            bool isSuccess = false;
            var cat = ctx.Products.Find(id);
            if (cat != null)
            {
                ctx.Products.Remove(cat);
                ctx.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        IEnumerable<Product> IService<Product, int>.Get()
        {
            var cats = ctx.Products.ToList();
            return cats;
        }

        Product IService<Product, int>.Get(int id)
        {
            var cat = ctx.Products.Find(id);
            return cat;
        }

        bool IService<Product, int>.Update(int id, Product entity)
        {
            bool isSuccess = false;
            var prd = ctx.Products.Find(id);
            if (prd != null)
            {
                prd.ProductName = entity.ProductName;
                prd.UnitPrice = entity.UnitPrice;
                prd.CategoryId = entity.CategoryId;
                ctx.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
