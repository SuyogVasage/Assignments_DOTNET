using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBindersController : ControllerBase
    {
        private readonly IService<Product, int> prdServ;

        public ProductBindersController(IService<Product, int> serv)
        {
            prdServ = serv;
        }

        //FromBody: The Data received from HTTP Request Body for POST Request will be
        //1.Parsed 2. Mapped with CLR Object based on Property NAmes
        [HttpPost]
        public IActionResult Post([FromBody] CatProd product)
        {
            if (ModelState.IsValid)
            {
                //var res = catServ.GetAsync(id).Result;
                foreach (var item in product.Products)
                {
                    //item.CategoryRowId = 2;
                    var res = prdServ.CreateAsync(item).Result;
                }
                //var res = prdServ.CreateAsync(product);
                return Ok(product);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        ////The Form Post, The data is send using Name:Value pair
        ////NAme Must match with Property from CLR Object
        //[HttpPost]
        //[ActionName("PostForm")]
        //public IActionResult PostForm([FromForm] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var res = prdServ.CreateAsync(product);
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}
        //[HttpPost]
        //[ActionName("PostHeader")]
        //public IActionResult PostHeader([FromHeader] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var res = prdServ.CreateAsync(product);
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        ////QueryStrig: Portion of URL After Question Mark in Name=Value pair
        ////FromQuery
        ////USed to Parse the QueryString and Map Name=Value pait in its appearnace order with
        ////CLR Object that is the input parameter to Action Method
        //[HttpPost]
        //[ActionName("PostQuery")]
        ////public IActionResult PostQuery(string ProductId, string ProductName, string Description, int CategoryRowId)
        //public IActionResult PostQuery([FromQuery] Product product)
        //{
        //    //var product = new Product()
        //    //{
        //    //     ProductId = ProductId,
        //    //     ProductName = ProductName,
        //    //     Description = Description,
        //    //     CategoryRowId = CategoryRowId
        //    //};
        //    if (ModelState.IsValid)
        //    {
        //        var res = prdServ.CreateAsync(product);
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        ////Parse the URL upto
        ////Server/api/COntrollerName/ActionNAme/{ROUTE-VALUES-FROM-THIS-ONWARDS}
        //// And Map with CLR Object that is the input parameter to Action Method

        //[HttpPost("{ProductId}/{ProductName}/{Description}/{CategoryRowId}")]
        //[ActionName("PostRoute")]
        //public IActionResult PostRoute([FromRoute] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var res = prdServ.CreateAsync(product);
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

    }
}
