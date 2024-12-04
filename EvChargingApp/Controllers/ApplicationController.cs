using Microsoft.AspNetCore.Mvc;
using EvChargingApp.Models; // Namespace for your models
using System.Linq; // Required for querying the database

[ApiController]
[Route("[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ApplicationController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("submit-form")]
public IActionResult SubmitForm([FromBody] ApplicationData formData)
{
    if (formData == null)
    {
        return BadRequest("Invalid form data.");
    }

    _context.Applications.Add(formData);
    _context.SaveChanges();

    return Ok("Form submitted successfully!");
}



    // Get all applications
    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var applications = _context.Applications.ToList();
        return Ok(applications); // Returns data as JSON
    }
}
