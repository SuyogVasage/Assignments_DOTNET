using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatProdController : ControllerBase
    {
        private readonly IService<Product, int> prodService;
        private readonly IService<Category, int> catService;

        public CatProdController(IService<Category, int> catService, IService<Product, int> prodService)
        {
            this.catService = catService;
            this.prodService = prodService;
        }

//        [HttpPost]
//        public IActionResult Post(CatProd product)
//        {
//            if (ModelState.IsValid)
//            {
//                var cat = new Category()
//                {
//                    CategoryID = product.CategoryId,
//                    CategoryName = product.CategoryName,
//                    BasePrice = product.BasePrice,
//                };
//                var catResultant = catService.CreateAsync(cat).Result;
//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//                foreach (var item in product.Products)
//                {
//                    item.CategoryRowID = catResultant.CategoryRowID;
//                    var res = prodService.CreateAsync(item).Result;
//                }
//#pragma warning restore CS8602 // Dereference of a possibly null reference.
//                return Ok(product);
//            }
//            else
//            {
//                return BadRequest(ModelState);
//            }
//        }

        [HttpPost]
        public async Task<IActionResult> Post(categProd catpro)
        {
            var catResultant = await catService.CreateAsync(catpro.Category);
            foreach (var item in catpro.Products)
            {
                item.CategoryRowID = catResultant.CategoryRowID;
                var res = await prodService.CreateAsync(item);
            }

            return Ok("Done");
        }


    }
}
