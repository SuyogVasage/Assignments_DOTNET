using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IService<Product, int> prodService;
        private readonly IService<Category, int> catService;

        public SearchController(IService<Category, int> catService, IService<Product, int> prodService)
        {
            this.catService = catService;
            this.prodService = prodService;
        }

        [HttpGet("{Name}")]
        public IActionResult Search(string Name)   
        {
            if(Name != null)
            {
                var catResultant = catService.GetAsync().Result.Where(x => x.CategoryName == Name).Select(y => y.CategoryRowID).FirstOrDefault();
                var product = prodService.GetAsync().Result.Where(x => x.CategoryRowID == catResultant);
                return Ok(product);
            }
            else
            {
                return BadRequest("Wrong Category Name");
            }
               
        }

        [HttpPost]
        public IActionResult Sea(string? CatName,string Name, string? ProdName)
        {
            if (ModelState.IsValid)
            {
               if(Name == "AND")
               {
                    var catResultant = catService.GetAsync().Result.Where(x => x.CategoryName == CatName).Select(y => y.CategoryRowID).FirstOrDefault();
                    var product = prodService.GetAsync().Result.Where(x => x.CategoryRowID == catResultant).Select(y => y.ProductName);
                    foreach(var item in product)
                    {
                        if (item == ProdName)
                        {
                            var productInfo = prodService.GetAsync().Result.Where(x => x.ProductName == ProdName).FirstOrDefault();
                            var catInfo = catService.GetAsync().Result.Where(x => x.CategoryName == CatName).FirstOrDefault();
                            catANDprod cc = new catANDprod();
                            cc.CategoryRowID = catInfo.CategoryRowID;
                            cc.CategoryName = catInfo.CategoryName;
                            cc.BasePrice = catInfo.BasePrice;
                            cc.ProductRowID = productInfo.ProductRowID;
                            cc.ProductName = productInfo.ProductName;
                            cc.Price = productInfo.Price;
                            return Ok(cc);
                        }
                    }
                    
               }

               if(Name == "OR")
                {
                    if (CatName != null && ProdName != null)
                    {
                        var catID = catService.GetAsync().Result.Where(x => x.CategoryName == CatName).Select(x => x.CategoryRowID).FirstOrDefault();
                        if (catID != 0)
                        {
                            var catRes = catService.GetAsync(catID).Result;
                            var proExistance = prodService.GetAsync().Result.Where(x => x.CategoryRowID == catID);
                            if (proExistance != null)
                            {
                                var product = proExistance.Where(x => x.ProductName.ToLower() == ProdName.ToLower());
                                CatProd categoryProduct = new CatProd()
                                {
                                    CategoryRowId = catID,
                                    CategoryName = catRes.CategoryName,
                                    BasePrice = catRes.BasePrice,
                                };
                                categoryProduct.Products = new List<Product>();
                                foreach (Product p in product)
                                {
                                    categoryProduct.Products.Add(new Product() { CategoryRowID = p.CategoryRowID, ProductName = p.ProductName, ProductID = p.ProductID });
                                }
                                return Ok(categoryProduct);
                            }
                            else
                            {
                                return Ok(catRes);
                            }
                        }
                        else
                        {
                            var prod = prodService.GetAsync().Result.Where(x => x.ProductName.ToLower() == ProdName.ToLower());
                            if (prod.Count() != 0)
                            {
                                return Ok(prod);
                            }
                            else
                            {
                                return BadRequest("Neither Product Nor Category Exist");
                            }
                        }
                    }
                    else if (CatName != null)
                    {
                        var catID = catService.GetAsync().Result.Where(x => x.CategoryName == CatName).Select(x => x.CategoryRowID).FirstOrDefault();
                        if (catID != 0)
                        {
                            var catRes = catService.GetAsync(catID).Result;
                            return Ok(catRes);
                        }
                        else
                        {
                            return BadRequest("Category Not Present");
                        }
                    }
                    else if (ProdName != null)
                    {
                        var prod = prodService.GetAsync().Result.Where(x => x.ProductName.ToLower() == ProdName.ToLower());
                        if (prod.Count() != 0)
                        {
                            return Ok(prod);
                        }
                        else
                        {
                            return BadRequest("Product Not Present");
                        }
                    }
               }
                return BadRequest("Wrong Data");
                
            }
            else
            {
               return BadRequest("Something Went Wrong");
            }

        }
    }
}
