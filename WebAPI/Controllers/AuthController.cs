using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [ActionName("register")]
        public async Task<IActionResult> CreateUser(RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.RegisterNewUserAsync(user);

                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [ActionName("login")]
        public async Task<IActionResult> Login(LoginUser inputModel)
        {
            if (ModelState.IsValid)
            {
                var token = await _authService.AuthenticateUserAsync(inputModel);
                if (token == null)
                {
                    return Unauthorized("The Authentication Failed");
                }
                // send token to client
                var ResponseData = new ResponseData()
                {
                    Message = token
                };

                return Ok(ResponseData);
            }
            return BadRequest(ModelState);
        }
    }
}

//Token
//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6IjFhYjBkOGU0LWIzYjUtNGRhYy05YjQ4LTA2MGEyOTYwMmQ0MCIsIm5iZiI6MTY0OTMxOTYzMiwiZXhwIjoxNjQ5MzIwODMyLCJpYXQiOjE2NDkzMTk2MzJ9.v-dE2yYvDzybx7kxi3ei8-5sEu28WgKBrhTG-reQMMA

