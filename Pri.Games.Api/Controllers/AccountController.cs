using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pri.Ca.Core.Entities;
using Pri.Games.Api.DTOs.Request.Account;
using Pri.Games.Api.DTOs.Response.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pri.Games.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountLoginDto accountLoginDto)
        {
            //authenticate the user using identity
            var result = await _signInManager.PasswordSignInAsync(accountLoginDto.Username, accountLoginDto.Password,false,false);
            if(!result.Succeeded)
            {
                return Unauthorized();
            }
            //get the user
            var user = await _userManager.FindByNameAsync(accountLoginDto.Username);
            //get the claims
            var claims = await _userManager.GetClaimsAsync(user);
            //add userId to claims
            //generate the security key
            var securityKey = 
                new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigninKey")));
            //generate token
            var token = new JwtSecurityToken
                (
                    audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                    issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                    claims: claims,
                    expires: DateTime.Now.AddDays(_configuration.GetValue<int>("JWTConfiguration:TokenExpiration")),
                    signingCredentials: new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256)
                );
            //serializen
            var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new AccountLoginResponseDto { Token = serializedToken});
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(AccountRegisterDto accountRegisterDto)
        {
            //create a user
            var user = new ApplicationUser
            {
                Firstname = accountRegisterDto.Firstname,
                Lastname = accountRegisterDto.Lastname,
                DateOfBirth = accountRegisterDto.DateOfBirth,
                UserName = accountRegisterDto.Username,
                Email = accountRegisterDto.Username,
            };
            //store using _userManager
            var result = await _userManager.CreateAsync(user,
                accountRegisterDto.Password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            //add claims to user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.PrimarySid, user.Id),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToShortDateString()),
            };
            result = await _userManager.AddClaimsAsync(user, claims);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok("user created");
        }
    }
}
