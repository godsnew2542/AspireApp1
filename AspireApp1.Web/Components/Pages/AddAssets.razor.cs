using AspireApp1.Web.ServicesApi;
using Microsoft.AspNetCore.Components;
using Model.Entity;
using MudBlazor;

namespace AspireApp1.Web.Components.Pages;

public partial class AddAssets
{
    [Inject] private NavigationManager navigationManager { get; set; } = null!;
    [Inject] private ISnackbar snackbar { get; set; } = null!;

    private MudForm form;
    private bool success { get; set; }
    Func<AssetCategories, string?> converterCategory { get; set; } = p => p?.Name;
    Func<Departments, string?> converterDepartments { get; set; } = p => p?.Name;
    Func<Users, string?> converterUser { get; set; } = p => p?.Name;


    private Api apiBackEnd { get; } = new();

    private readonly string[] _states =
    [
        "active", "in_repair", "disposed", "lost"
    ];

    private Assets assets { get; set; } = new();

    private List<AssetCategories> categories { get; set; } = new();
    private List<Departments> departments { get; set; } = new();
    private List<Users> users { get; set; } = new();
    public DateTime? purchaseDate { get; set; } = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                categories = await apiBackEnd.GetAllCategories();
                departments = await apiBackEnd.GetAllDepartments();
                users = await apiBackEnd.GetAllUsers();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                StateHasChanged();
            }
        }
    }

    private async Task onAddData()
    {
        await form.Validate();

        if (!success)
        {
            return;
        }

        if (assets.Category != null)
        {
            assets.CategoryId = assets.Category.Id;
        }

        if (assets.Department != null)
        {
            assets.DepartmentId = assets.Department.Id;
        }

        if (assets.User != null)
        {
            assets.UserId = assets.User.Id;
        }

        if (purchaseDate != null)
        {
            assets.PurchaseDate = new DateOnly(purchaseDate!.Value.Year, purchaseDate!.Value.Month, purchaseDate!.Value.Day);
        }

        try
        {
            var rusult = await apiBackEnd.AddAssets(assets);

            if (rusult != null)
            {
                apiBackEnd.SnackbarOpen(snackbar, Defaults.Classes.Position.TopRight, "บันทึกข้อมูลสำเร็จ", Severity.Success);
                navigationManager.NavigateTo("weather");
            }
            else
            {
                apiBackEnd.SnackbarOpen(snackbar, Defaults.Classes.Position.TopRight, "เกิดข้อผิดพลาดในการบันทึกข้อมูล", Severity.Warning);
            }
        }
        catch (Exception ex)
        {
            apiBackEnd.SnackbarOpen(snackbar, Defaults.Classes.Position.TopRight, apiBackEnd.ExceptionLog(ex), Severity.Error);
        }
        finally
        {
            assets = new();
            purchaseDate = null;
        }
    }
}
