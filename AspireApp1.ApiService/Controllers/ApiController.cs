using AspireApp1.ApiService.IServices;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;

namespace AspireApp1.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController(IConnectDbService connectDb) : ControllerBase
{
    [HttpGet]
    [Route("/api/Customer")]
    public async Task<IActionResult> GetAllResumeCustomer()
    {
        try
        {
            //List<ResumeCustomer> result = await connectDb.GetAllResumeCustomer();
            List<ResumeCustomer> result = new();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    [Route("/api/CustomerById")]
    public async Task<IActionResult> GetAllResumeCustomer(string? id)
    {
        try
        {
            //ResumeCustomer? result = await connectDb.GetResumeCustomerById(id);
            ResumeCustomer? result = new();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    [Route("/api/Customer")]
    public async Task<IActionResult> AddResumeCustomer(ResumeCustomer resume)
    {
        try
        {
            //ResumeCustomer? result = await connectDb.AddResumeCustomer(resume);
            ResumeCustomer? result = new();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut]
    [Route("/api/Customer")]
    public async Task<IActionResult> UpdateResumeCustomer(ResumeCustomer resume)
    {
        try
        {
            //await connectDb.UpdateResumeCustomer(resume);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete]
    [Route("/api/Customer")]
    public async Task<IActionResult> UpdateResumeCustomer([FromQuery] string? id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NoContent();
        }
        try
        {
            //await connectDb.DeleteResumeCustomerById(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
