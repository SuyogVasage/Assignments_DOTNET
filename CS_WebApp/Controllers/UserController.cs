using Microsoft.AspNetCore.Mvc;
using CS_WebApp.Models;
using CS_WebApp.Services;

namespace CS_WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IService<User, int> userService;
        /// <summary>
        /// Inject The IService<Department, int> aka DeptService in it
        /// </summary>
        public UserController(IService<User, int> service)
        {
            userService = service;
        }
        public IActionResult Index()
        {
            var result = userService.GetAsync().Result;
            return View(result);
        }

        public IActionResult Create()
        {
            var user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var result = userService.CreateAsync(user).Result;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// The http get request must pass the 
        /// Route parameter as 'id' (
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var result = userService.GetAsync(id).Result;

            //return a view the record to be edited
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            var result = userService.UpdateAsync(id, user).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = userService.GetAsync(id).Result;
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(int id, User user)
        {
            var result = userService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }
    }
}

