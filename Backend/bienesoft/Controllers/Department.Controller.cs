using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bienesoft.Models;
using bienesoft.Services;

namespace Bienesoft.Controllers
{
    [Controller]
    [Route("/api[controller]")]
    public class DepartmentController : Controller
    {
        public readonly UserServices _userServices;
        public DepartmentController(UserServices userServices)
        {
            _userServices = userServices;
        }


        [HttpGet("AlLDepartment")]
        public ActionResult<IEnumerable<DepartmentModel>> AlLDepartment()
        {
            var Departments = _userServices.GetDepartmentModels();
            if (Departments == null)
            {
                return NotFound("No se encontraron departamentos.");
            }
            return Ok(Departments);
        }
    }
     
}  