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
    //submit form
    [HttpPost("submit-form")]
public IActionResult SubmitForm([FromBody] ApplicationData formData)
{
    Console.WriteLine("Received a request to submit the form.");

    if (formData == null)
    {
        Console.WriteLine("Form data is null.");
        return BadRequest("Invalid form data.");
    }

    try
    {
        Console.WriteLine($"Form Data: {formData.FullName}, {formData.AddressLine1}"); 

        _context.Applications.Add(formData);
        _context.SaveChanges();

        return Ok("Form submitted successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error in SubmitForm: {ex.Message}");
        Console.WriteLine(ex.StackTrace);
        return StatusCode(500, "An error occurred while submitting the form.");
    }
}


    // Get all applications
    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var applications = _context.Applications.ToList();
        return Ok(applications); 
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
