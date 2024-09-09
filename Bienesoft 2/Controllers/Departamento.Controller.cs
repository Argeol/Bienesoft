using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bienesoft.Models;

namespace Bienesoft.Controllers
{
    [Controller]
    [Route("/api[controller]")]
    public class DepartamentoController : Controller
    {
        [HttpPost]
        public IActionResult Create(DepartamentoModel Departamento)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpGet("read")]
        public IActionResult Read()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpPost("Update")]

        public IActionResult Update()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }

        }
        [HttpDelete("Delete")]
        public IActionResult Delete()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }

        }
    }
}