using BackendFinalGrupo10.DTOs;
using BackendFinalGrupo10.Entitys;
using BackendFinalGrupo10.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendFinalGrupo10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IUserRepository _userRepository;

        public AuthenticationController(IConfiguration configuration, IUserRepository userRepository)
        {

            _configuration = configuration;
            _userRepository = userRepository;

        }




        [HttpPost]
        public ActionResult<string> Auth(AuthenticationDto authDto)
        {
            // Verificamos credenciales
            var user = _userRepository.ValidateUser(authDto);


            if (user is null)
            {
                return Unauthorized(); 
            }
                

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);


            var claimsForToken = new List<Claim>
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("userName", user.UserName), 
                new Claim("role", user.Rango.ToString())
            };
           

            var jwtSecurityToken = new JwtSecurityToken( 
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials);


            var tokenToReturn = new JwtSecurityTokenHandler() 
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }


    }
}
