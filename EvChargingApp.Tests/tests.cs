using Xunit;
using Microsoft.EntityFrameworkCore;
using EvChargingApp.Models;
using EvChargingApp.Controllers; 
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
public void Delete_ReturnsNotFound_WhenIdDoesNotExist()
{
    // Arrange
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase_DeleteNonExistent")
        .Options;

    using var context = new ApplicationDbContext(options);
    context.Applications.Add(new ApplicationData 
    { 
        Id = 1, 
        AddressLine1 = "123 Test Street", 
        Postcode = "AB12 3CD", 
        FullName = "John Doe", 
        VehicleRegistrationNumber = "AB12CDE", 
        EmailAddress = "john.doe@example.com" 
    });
    context.SaveChanges();

    var controller = new ApplicationController(context);

    // Act
    var result = controller.Delete(99); // Try to delete ID 99, which doesn't exist

    // Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("No application found with ID 99.", notFoundResult.Value);

    Assert.Single(context.Applications); // Ensure no entries were deleted
}
    [Fact]
public void SubmitForm_AddsApplicationToDatabase()
{
    // Arrange
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase_SubmitForm")
        .Options;

    using var context = new ApplicationDbContext(options);
    var controller = new ApplicationController(context);

    var formData = new ApplicationData
    {
        AddressLine1 = "123 Test Street",
        Postcode = "AB12 3CD",
        FullName = "John Doe",
        VehicleRegistrationNumber = "AB12CDE",
        EmailAddress = "john.doe@example.com"
    };

    // Act
    var result = controller.SubmitForm(formData);

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    Assert.Equal("Form submitted successfully!", okResult.Value);

    Assert.Single(context.Applications); // Ensure the database contains one entry
    var addedApplication = context.Applications.First();
    Assert.Equal("123 Test Street", addedApplication.AddressLine1);
    Assert.Equal("AB12 3CD", addedApplication.Postcode);
    Assert.Equal("John Doe", addedApplication.FullName);
    Assert.Equal("AB12CDE", addedApplication.VehicleRegistrationNumber);
    Assert.Equal("john.doe@example.com", addedApplication.EmailAddress);
}


    [Fact]
public void Delete_RemovesSpecificApplication()
{
    // Arrange
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase_DeleteOne")
        .Options;

    using var context = new ApplicationDbContext(options);
    context.Applications.Add(new ApplicationData 
    { 
        Id = 1, 
        AddressLine1 = "123 Test Street", 
        Postcode = "AB12 3CD", 
        FullName = "John Doe", 
        VehicleRegistrationNumber = "AB12CDE", 
        EmailAddress = "john.doe@example.com" 
    });
    context.Applications.Add(new ApplicationData 
    { 
        Id = 2, 
        AddressLine1 = "456 Test Avenue", 
        Postcode = "XY45 6ZT", 
        FullName = "Jane Doe", 
        VehicleRegistrationNumber = "XY45ZTG", 
        EmailAddress = "jane.doe@example.com" 
    });
    context.SaveChanges();

    var controller = new ApplicationController(context);

    // Act
    var result = controller.Delete(1);

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    Assert.Equal("Application with ID 1 has been deleted.", okResult.Value);

    Assert.Single(context.Applications); // One application should remain
    Assert.Equal(2, context.Applications.First().Id); // The remaining application should have ID 2
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
