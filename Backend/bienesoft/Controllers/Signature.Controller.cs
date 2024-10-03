using Bienesoft.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bienesoft.Controllers
{
	[Controller]
	[Route("/api[controller]")]
	public class FirmaController : Controller
	{
		[HttpPost]
		public IActionResult Create(SignatureModel firma)
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
