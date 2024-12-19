namespace EvChargingApp.Controllers
{
using Microsoft.AspNetCore.Mvc;
using EvChargingApp.Models; 
using System.Linq; 

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

    // Delete all applications
    [HttpDelete("delete-all")]
    public IActionResult DeleteAll()
    {
        var allApplications = _context.Applications.ToList();
        if (!allApplications.Any())
        {
            return NotFound("No applications to delete.");
        }

        _context.Applications.RemoveRange(allApplications);
        _context.SaveChanges();

        return Ok("All applications have been deleted.");
    }

    // Delete a specific application by ID
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var application = _context.Applications.FirstOrDefault(a => a.Id == id);
        if (application == null)
        {
            return NotFound($"No application found with ID {id}.");
        }

        _context.Applications.Remove(application);
        _context.SaveChanges();

        return Ok($"Application with ID {id} has been deleted.");
    }
}
}
