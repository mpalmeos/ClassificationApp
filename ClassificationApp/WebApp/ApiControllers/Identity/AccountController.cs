using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Domain.Identity;
using Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApp.Areas.Identity.Pages.Account;

namespace WebApp.ApiControllers.Identity
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        

        public AccountController(SignInManager<AppUser> signInManager, IConfiguration configuration, UserManager<AppUser> userManager, ILogger<RegisterModel> logger, IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO model)
        {
            var appUser = await _userManager.FindByEmailAsync(model.Email);
            
            if (appUser == null)
            {
                // user is not found, return 403
                _logger.LogInformation("User not found.");
                return StatusCode(403);
            }
            
            var result = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);
            
            if (result.Succeeded)
            {
                // create claims based user 
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
          
                // get the Json Web Token
                var jwt = JwtHelper.GenerateJwt(
                    claimsPrincipal.Claims, 
                    _configuration["JWT:Key"], 
                    _configuration["JWT:Issuer"], 
                    int.Parse(_configuration["JWT:ExpireDays"]));
                _logger.LogInformation("Token generated for user");
                return Ok(new {token = jwt});
            }

            return StatusCode(403);
        }
        
        [HttpPost]
        public async Task<string> Register([FromBody] RegisterDTO model)
        {
            return "foo";
        }

        public class LoginDTO
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        
        public class RegisterDTO
        {
            public string Email { get; set; }
            [Required]
            [MinLength(6)]
            public string Password { get; set; }
        }
    }
}