using Bienesoft.Function;
using Bienesoft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Bienesoft.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserCotroller : Controller

    {
        public IConfiguration _Configuration { get; set; }
        public GeneralFuction FuctionGeneral;
        public JWTModel JWT;
        public UserCotroller(IConfiguration configuration)
        {
            _Configuration = configuration;
            FuctionGeneral = new GeneralFuction(configuration);
            JWT = _Configuration.GetSection("JWT").Get<JWTModel>();
        }
        [HttpPost]
        public IActionResult login(LoginUser login)
        {
            try {
                
                var key = Encoding.UTF8.GetBytes("jdiewyrfrdlirjmdñdmsokomrdmnsdndjhfuergfkdsj");

                ClaimsIdentity subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim ("NameUser",login.name)
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(JWT.JWTExpireTime)),
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);


                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception ex)
            {
                FuctionGeneral.addloig(ex.ToString());

                return StatusCode(500, ex.ToString());
            }
        }
        [HttpPost("ResetPassUser")]

        public async Task<IActionResult> ResetPassWord(ResetPassUser user)
        {
            try
            {
                GeneralFuction funciones = new GeneralFuction(_Configuration);
                var reponse = await funciones.SendEmail(user.name);
                if (reponse.Status)
                {
                    return Ok(reponse);
                }
                return BadRequest(reponse);
            }
            catch (Exception ex)
            {
                FuctionGeneral.addloig(ex.ToString());
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpPost("CreateUser")]

        public IActionResult CreateUser(User user)

        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                FuctionGeneral.addloig(ex.ToString());
                return StatusCode(500, ex.ToString());
            }
        }
    }
}





