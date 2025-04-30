using Model.Entity;
using MudBlazor;
using System.Text;
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

    public async Task<List<Assets>> GetAllAssets()
    {
        using var client = new HttpClient();

        try
        {
            var response = await client.GetAsync($"{baseApi}/api/Assets");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Assets>>(result, JsonSerializerOptions)!;
            }
            return new List<Assets>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<AssetCategories>> GetAllCategories()
    {
        using var client = new HttpClient();

        try
        {
            var response = await client.GetAsync($"{baseApi}/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<AssetCategories>>(result, JsonSerializerOptions)!;
            }
            return new List<AssetCategories>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Departments>> GetAllDepartments()
    {
        using var client = new HttpClient();

        try
        {
            var response = await client.GetAsync($"{baseApi}/api/Departments");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Departments>>(result, JsonSerializerOptions)!;
            }
            return new List<Departments>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Users>> GetAllUsers()
    {
        using var client = new HttpClient();

        try
        {
            var response = await client.GetAsync($"{baseApi}/api/Users");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Users>>(result, JsonSerializerOptions)!;
            }
            return new List<Users>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Assets?> AddAssets(Assets assets)
    {
        Assets body = assets;
        body.User = null;
        body.Category = null;
        body.Department = null;

        using var client = new HttpClient();

        var json = JsonSerializer.Serialize(body, JsonSerializerOptions);
        HttpContent jsonStr = new StringContent(json, Encoding.UTF8, "application/json");
        try
        {
            var response = await client.PostAsync($"{baseApi}/api/Assets", jsonStr);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Assets>(result, JsonSerializerOptions)!;
            }
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }


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



    public string ExceptionLog(Exception ex)
    {
        return (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
    }

    public void SnackbarOpen(ISnackbar snackbar, string position, string message, Severity severity = Severity.Normal)
    {
        snackbar.Clear();
        snackbar.Configuration.PositionClass = position;
        snackbar.Configuration.VisibleStateDuration = 8000;

        snackbar.Add(message, severity);
    }
}
