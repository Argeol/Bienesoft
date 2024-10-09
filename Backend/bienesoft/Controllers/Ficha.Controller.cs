using bienesoft.Funcions;
using bienesoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bienesoft.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class FichaController : Controller
    {
        public GeneralFunction GeneralFunction;


        [HttpPost("CreateFicha")]
        public IActionResult Create(FichaModel ficha)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                GeneralFunction.Addlog(ex.Message);
                return StatusCode(500, ex.ToString());

            }
        }
        [HttpGet("GetFicha")]

        public IActionResult Get(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                {
                    GeneralFunction.Addlog(ex.Message);
                    return StatusCode(500, ex.ToString());
                }
            }
        }
        [HttpGet("GetsFicha")]

        public IActionResult Gets(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                {
                    GeneralFunction.Addlog(ex.Message);
                    return StatusCode(500, ex.ToString());
                }
            }
        }
        [HttpPost("UpdateFicha")]
        public IActionResult Update(int Id, FichaModel ficha)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                GeneralFunction.Addlog(ex.Message);
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpDelete("DeleteFicha")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                GeneralFunction.Addlog(ex.Message);
                return StatusCode(500, ex.ToString());
            }
        }

    }
}