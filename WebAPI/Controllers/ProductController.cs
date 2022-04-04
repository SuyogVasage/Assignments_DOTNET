using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product, int> prodService;
        private readonly IService<Category, int> catServ;

        public ProductController(IService<Product, int> serv, IService<Category, int> catServ)
        {
            prodService = serv;
            this.catServ = catServ;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = prodService.GetAsync().Result;
            // JSON Serialize the Resonse
            return Ok(res);
        }
        /// <summary>
        /// String Template as '{id}'
        /// This MUST atche with the parameter name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = prodService.GetAsync(id).Result;
            // JSON Serialize the Resonse
            return Ok(res);
        }
        /// <summary>
        /// CLR Type will be by default mapped by ApiControllerAttribute class
        /// so no Template is needed
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Product prod)
        {
            var bPrice = catServ.GetAsync().Result.Where(x => x.CategoryRowID == prod.CategoryRowID).Select(y => y.BasePrice).FirstOrDefault();
            if (prod.Price < bPrice)
            {
                return BadRequest("The Product Price Cannot be less than Base Price of Category");
            }

            if (ModelState.IsValid)
            {
                var res = prodService.CreateAsync(prod).Result;
                return Ok(res);
            }
            else
            {
                // Data is Invalid
                return BadRequest(ModelState);
            }
        }
        /// <summary>
        /// Same as HttpPost
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product prod)
        {
            // Check for the avilability of the record
            //var record = prodService.GetAsync(id).Result;
            //if (record == null) return NotFound($"BAsed of Category Row Id {id} the record is not found");

            //// Check if the id from header is mapping with the id from the Body
            //if (id != prod.ProductRowID)
            //    return BadRequest($"Id for seaarch {id} does not match with Category Row Id in Body {prod.ProductRowID}");

            var bPrice = catServ.GetAsync().Result.Where(x => x.CategoryRowID == prod.CategoryRowID).Select(y => y.BasePrice).FirstOrDefault();
            if (prod.Price < bPrice)
            {
                return BadRequest("The Product Price Cannot be less than Base Price of Category");
            }

            if (ModelState.IsValid)
            {
                var res = prodService.UpdateAsync(id, prod).Result;
                return Ok(res);
            }
            else
            {
                // Data is Invalid
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = prodService.DeleteAsync(id).Result;
            return Ok(res);
        }
    }
}

