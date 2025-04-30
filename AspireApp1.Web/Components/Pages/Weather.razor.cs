using AspireApp1.Web.ServicesApi;
using Microsoft.AspNetCore.Components;
using Model.Entity;
using MudBlazor;

namespace AspireApp1.Web.Components.Pages;

public partial class Weather
{
    [Inject] private NavigationManager navigationManager { get; set; } = null!;
    [Inject] private ISnackbar snackbar { get; set; } = null!;

    private Api apiBackEnd { get; } = new();

    private List<Assets> assets { get; set; } = new();
    private IEnumerable<Assets> Elements { get; set; } = new List<Assets>();


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                assets = await apiBackEnd.GetAllAssets();
                onSetData("active");
            }
            catch (Exception ex)
            {
                apiBackEnd.SnackbarOpen(snackbar, Defaults.Classes.Position.TopRight, apiBackEnd.ExceptionLog(ex), Severity.Error);
            }
            finally
            {
                StateHasChanged();
            }
        }
    }

    private int getDataCount(string? status)
    {
        if (!assets.Any())
        {
            return 0;
        }

        return assets.Count(x => x.Status == status);
    }

    private void onSetData(string? status)
    {
        if (!assets.Any())
        {
            Elements = new List<Assets>();
            return;
        }

        Elements = assets.Where(x => x.Status == status).ToList();
    }

    private void onAddAssetsPage()
    {
        navigationManager.NavigateTo("/addAssets");
    }
}
