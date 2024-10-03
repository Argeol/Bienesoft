using bienesoft.Funcions;
using bienesoft.models;
using bienesoft.Models;
using bienesoft.Services;
using Bienesoft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace bienesoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginUserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly JWTModels _jwtSettings;
        private readonly UserServices _userServices;
        private readonly GeneralFunction _generalFunction;

        public LoginUserController(IConfiguration configuration, UserServices userServices, GeneralFunction generalFunction)
        {
            _configuration = configuration;
            _userServices = userServices;
            _jwtSettings = configuration.GetSection("JWT").Get<JWTModels>();
            _generalFunction = generalFunction;
        }

        [HttpPost]
        public IActionResult Create(loginUser user)
        {
            try
            {
                var key = Encoding.UTF8.GetBytes(_jwtSettings.keysecret);

                ClaimsIdentity subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("User", user.Email)
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtSettings.JWTExpireTime)),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception ex)
            {
                _generalFunction.Addlog(ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor.");
            }
        }

        [HttpPost("ResetPassUser")]
        public async Task<IActionResult> ResetPassword(ResetPassUser user)
        {
            try
            {
                // Implementa aquí la lógica para enviar el correo de restablecimiento de contraseña
                // Ejemplo: await EnviarCorreoRestablecimiento(user.Email);
                // Reemplaza con tu implementación real
                // ...

                return Ok("Correo de restablecimiento de contraseña enviado correctamente.");
            }
            catch (Exception ex)
            {
                _generalFunction.Addlog(ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor.");
            }
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(User user)
        {
            try
            {
                // Implementa aquí la lógica para crear un usuario
                // ...

                return Ok("Usuario creado correctamente.");
            }
            catch (Exception ex)
            {
                _generalFunction.Addlog(ex.ToString());
                return StatusCode(500, "Ocurrió un error en el servidor.");
            }
        }

        [HttpGet("AllUsers")]
        public ActionResult<IEnumerable<LearnerModel>> AllUser()
        {
            var learners = _userServices.GetLearnerModels();
            if (learners == null)
            {
                return NotFound("No se encontraron usuarios.");
            }
            return Ok(learners);
        }

    }
}
