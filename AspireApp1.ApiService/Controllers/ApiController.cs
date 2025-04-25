using AspireApp1.ApiService.IServices;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;

namespace AspireApp1.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController(IConnectDb connectDb) : ControllerBase
{
    [HttpGet]
    [Route("/api/Customer")]
    public async Task<IActionResult> GetAllResumeCustomer()
    {
        try
        {
            List<ResumeCustomer> result = await connectDb.GetAllResumeCustomer();
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Log the error here if you want
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    [Route("/api/CustomerById")]
    public async Task<IActionResult> GetAllResumeCustomer(string? id)
    {
        try
        {
            ResumeCustomer? result = await connectDb.GetResumeCustomerById(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Log the error here if you want
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
