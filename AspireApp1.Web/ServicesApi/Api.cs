using Model.Entity;
using System.Text.Json;

namespace AspireApp1.Web.ServicesApi;

public class Api
{
    private string baseApi { get; } = "https://localhost:7590";
    private JsonSerializerOptions JsonSerializerOptions { get; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
    };

    public async Task<List<ResumeCustomer>> GetAllResumeCustomer()
    {
        using var client = new HttpClient();

        try
        {
            var response = await client.GetAsync($"{baseApi}/api/Customer");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<ResumeCustomer>>(result, JsonSerializerOptions)!;
            }
            return new List<ResumeCustomer>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    //public async Task<ResumeCustomer?> GetResumeCustomerById(string? id)
    //{
    //    using var client = new HttpClient();
    //    var response = await client.GetAsync($"https://localhost:5001/api/CustomerById?id={id}");
    //    if (response.IsSuccessStatusCode)
    //    {
    //        var result = await response.Content.ReadAsStringAsync();
    //        return JsonConvert.DeserializeObject<ResumeCustomer>(result);
    //    }
    //    return null;
    //}
}
