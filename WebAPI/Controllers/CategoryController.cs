using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category, int> catServ;

        public CategoryController(IService<Category, int> serv)
        {
            catServ = serv;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = catServ.GetAsync().Result;
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
            var res = catServ.GetAsync(id).Result;
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
        public IActionResult Post(Category cat)
        {
            if (ModelState.IsValid)
            {
                var res = catServ.CreateAsync(cat).Result;
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
        public IActionResult Put(int id, Category cat)
        {
            // Check for the avilability of the record
            var record = catServ.GetAsync(id).Result;
            if (record == null) return NotFound($"BAsed of Category Row Id {id} the record is not found");

            // Check if the id from header is mapping with the id from the Body
            if (id != cat.CategoryRowID)
                return BadRequest($"Id for seaarch {id} does not match with Category Row Id in Body {cat.CategoryRowID}");

            if (ModelState.IsValid)
            {
                var res = catServ.UpdateAsync(id, cat).Result;
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
            var res = catServ.DeleteAsync(id).Result;
            return Ok(res);
        }
    }
}
