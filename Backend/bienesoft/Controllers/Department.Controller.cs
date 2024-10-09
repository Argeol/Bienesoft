using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bienesoft.Models;
using bienesoft.Services;
using bienesoft.Funcions;

namespace Bienesoft.Controllers
{
    [Controller]
    [Route("/api[controller]")]
    public class DepartmentController : Controller
    {
        public readonly DepartmentServices _departmentServices;
        public GeneralFunction GeneralFunction;
        public DepartmentController(DepartmentServices departmentServices, IConfiguration configuration)
        {
            _departmentServices = departmentServices;
            GeneralFunction = new GeneralFunction(configuration);
        }

        [HttpPost("DepartmentCreate")]
        public IActionResult Add(DepartmentModel department)
        {
            {
                if (department == null)
                {
                    return BadRequest("El modelo de departamento es nulo");
                }

                try
                {
                    _departmentServices.AddDepartmentModel(department);
                    return Ok("ya esta en la base de datos");
                }
                catch (Exception ex)
                {
                    GeneralFunction.Addlog(ex.Message);
                    return StatusCode(500, ex.ToString());
                }
            }
        }
        [HttpGet("AlLDepartment")]
        public ActionResult<IEnumerable<DepartmentModel>> AlLDepartment()
        {
            try
            {
                var Departments = _departmentServices.GetDepartmentModels();
                if (Departments == null)
                {
                    return NotFound("No se encontraron departamentos.");
                }
                return Ok(Departments);
            }
            catch (Exception ex)
            {
                GeneralFunction.Addlog(ex.Message);
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpDelete("DeleteDepartment")]
        public ActionResult Delete(int Id_Department)
        {
            try
            {
                _departmentServices.RemoveDepartmentModel(Id_Department);
                return Ok("Departamento Eliminado Exitosamente");
            }
            catch (Exception ex)
            {
                GeneralFunction.Addlog(ex.Message);
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpGet("ALLDepartamentOne")]
        public ActionResult<DepartmentModel> ALLDepartamentOne(int Id_Department)
        {
            try
            {
                var department = _departmentServices.GetDepartmentModelOne(Id_Department);
                if(department == null)
                {
                    return NotFound("Departamento no Encontrado");
                }
                return Ok(department);
            }
            catch (Exception ex)
            {

                GeneralFunction.Addlog(ex.Message);
                return StatusCode(500, ex.ToString());
            }
        }
        [HttpPut("UpdateDepartment")]
        public IActionResult Update(DepartmentModel department)
        {
            if (department == null)
            {
                return BadRequest("El modelo de departamento es nulo");
            }

            try
            {
                _departmentServices.UpdateDepartmentModel(department);
                return Ok("Departamento actualizado exitosamente");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                GeneralFunction.Addlog(ex.Message);
                return StatusCode(500, ex.ToString());

            }
        }
    }
     
}  