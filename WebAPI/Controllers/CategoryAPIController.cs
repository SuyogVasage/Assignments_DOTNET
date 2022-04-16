using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CategoryAPIController : ControllerBase
    {
        private readonly IService<Category, int> catServ;

        public CategoryAPIController(IService<Category, int> serv)
        {
            catServ = serv;
        }
        [HttpGet("/getall")]
        public async Task<IEnumerable<Category>> Get()
        {
            var res = await catServ.GetAsync();
            // JSON Serialize the Resonse
            return res;
        }
        /// <summary>
        /// String Template as '{id}'
        /// This MUST atche with the parameter name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/get/{id}")]
        public async Task<Category> Get(int id)
        {
            var res = await catServ.GetAsync(id);
            // JSON Serialize the Resonse
            return res;
        }
        /// <summary>
        /// CLR Type will be by default mapped by ApiControllerAttribute class
        /// so no Template is needed
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost("/create")]
        public async Task<Category> Post(Category cat)
        {


            if (ModelState.IsValid)
            {
                var res = await catServ.CreateAsync(cat);
                return res;
            }
            else
            {
                // Data is Invalid
                return null;
            }



        }
        /// <summary>
        /// Same as HttpPost
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPut("/update/{id}")]
        public async Task<Category> Put(int id, Category cat)
        {


            if (ModelState.IsValid)
            {
                var res = await catServ.UpdateAsync(id, cat);
                return res;
            }
            else
            {
                // Data is Invalid
                return null;
            }
        }
        [HttpDelete("/delete/{id}")]
        public async Task<Category> Delete(int id)
        {
            var res = await catServ.DeleteAsync(id);
            return res;
        }
    }
}
