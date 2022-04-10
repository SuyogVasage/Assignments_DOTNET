using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        // used to read settings from appsettings.json
        private readonly IConfiguration _config;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration config)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._config = config;
        }

        public async Task<ResponseData> RegisterNewUserAsync(RegisterUser user)
        {
            var response = new ResponseData();
            // Store the received data in IdentityUser class
            var registerUser = new IdentityUser() { UserName = user.Email, Email = user.Email };
            // Create User
            var result = await _userManager.CreateAsync(registerUser, user.Password);
            // If Successful returnSuccess
            if (result.Succeeded)
            {
                response.Message = $"User {user.Email} is registered Successfully";
            }
            else
            {
                // else return fail
                response.Message = $"User {user.Email} Registration Failed";
            }
            return response;
        }
        /// <summary>
        /// Method to Auteticate USer
        /// If SUccessfull then Generate JSON Web Token
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public async Task<string> AuthenticateUserAsync(LoginUser inputModel)
        {

            string jwtToken = "";
            // SIgnin the user
            var result = await _signInManager.PasswordSignInAsync(inputModel.UserName, inputModel.Password, false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                // Read Secret Key
                var secretKey = Convert.FromBase64String(_config["JWTSettings:SecretKey"]);
                // Read Expiry
                var expiryTimeSpan = Convert.ToInt32(_config["JWTSettings:ExpiryInMinuts"]);

                // CReate an IdenttyUSer object
                // this will be used fot creating Claim
                IdentityUser user = new IdentityUser(inputModel.UserName);

                // SecurityTokenDescriptor: Define the Information for
                // Generating Token
                var securityTokenDescription = new SecurityTokenDescriptor()
                {
                    Issuer = null,
                    Audience = null,
                    // SUrrently Only USer NAme is addded in Claim
                    Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("username",user.Id,ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(expiryTimeSpan),
                    IssuedAt = DateTime.UtcNow,
                    NotBefore = DateTime.UtcNow,
                    // Setting an Algorithm for Encryption
                    // and The Signeture
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
                };
                // Actually GeneratenJSON Web Token
                var jwtHandler = new JwtSecurityTokenHandler();
                // CReate Token based on Description
                var jwToken = jwtHandler.CreateJwtSecurityToken(securityTokenDescription);
                // Write Token in Response
                jwtToken = jwtHandler.WriteToken(jwToken);
            }
            else
            {
                jwtToken = "Login failed";
            }

            return jwtToken;
        }
    }
}
