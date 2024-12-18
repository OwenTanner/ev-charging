using Xunit;
using Microsoft.EntityFrameworkCore;
using EvChargingApp.Models;
using EvChargingApp.Controllers; // Your namespace
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class ApplicationControllerTests
{
    [Fact]
public void DeleteAll_RemovesAllApplications()
{
    // Arrange
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase_DeleteAll")
        .Options;

    using var context = new ApplicationDbContext(options);
    context.Applications.Add(new ApplicationData 
    { 
        AddressLine1 = "123 Test Street", 
        Postcode = "AB12 3CD", 
        FullName = "John Doe", 
        VehicleRegistrationNumber = "AB12CDE", 
        EmailAddress = "john.doe@example.com" 
    });
    context.Applications.Add(new ApplicationData 
    { 
        AddressLine1 = "456 Test Avenue", 
        Postcode = "XY45 6ZT", 
        FullName = "Jane Doe", 
        VehicleRegistrationNumber = "XY45ZTG", 
        EmailAddress = "jane.doe@example.com" 
    });
    context.SaveChanges();

    var controller = new ApplicationController(context);

    // Act
    var result = controller.DeleteAll();

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    Assert.Equal("All applications have been deleted.", okResult.Value);

    Assert.Empty(context.Applications); 
}

    [Fact]
    public void GetAll_ReturnsAllApplications()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var context = new ApplicationDbContext(options);
        context.Applications.Add(new ApplicationData 
{ 
    AddressLine1 = "123 Test Street", 
    Postcode = "AB12 3CD", 
    FullName = "John Doe", 
    VehicleRegistrationNumber = "AB12CDE", 
    EmailAddress = "john.doe@example.com" 
});

context.Applications.Add(new ApplicationData 
{ 
    AddressLine1 = "456 Test Avenue", 
    Postcode = "XY45 6ZT", 
    FullName = "Jane Doe", 
    VehicleRegistrationNumber = "XY45ZTG", 
    EmailAddress = "jane.doe@example.com" 
});

        context.SaveChanges();

        var controller = new ApplicationController(context);

        // Act
        var result = controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnData = Assert.IsAssignableFrom<List<ApplicationData>>(okResult.Value);

        
        Assert.Equal(2, returnData.Count());
    }
}
