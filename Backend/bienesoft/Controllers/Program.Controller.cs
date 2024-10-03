using bienesoft.Funcions;
using Bienesoft.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bienesoft.Controllers;

[ApiController]
[Route("Api/[Controller]")]
public class ProgramController : Controller
{
    public GeneralFunction GeneralFunction;


    [HttpPost("CreateProgram")]
    public IActionResult Create(ProgramController program)
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
    [HttpGet("GetProgram")]

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
    [HttpPost("UpdateProgram")]
    public IActionResult Update(int Id, ProgramController program)
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
    [HttpDelete("DeleteProgram")]
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