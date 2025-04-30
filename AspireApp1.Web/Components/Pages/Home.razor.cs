using Model.Entity;
using AspireApp1.Web.ServicesApi;
using static MudBlazor.CategoryTypes;

namespace AspireApp1.Web.Components.Pages;

public partial class Home
{
    private Api apiBackEnd { get; } = new();
    private List<ResumeCustomer> resumes { get; set; } = new();
    private bool isLoading { get; set; } = true;

    private IEnumerable<Assets> Elements { get; set; } = new List<Assets>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            isLoading = true;
            try
            {
                Elements = await apiBackEnd.GetAllAssets();
                resumes = await apiBackEnd.GetAllResumeCustomer();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                isLoading = false;
                StateHasChanged();
            }
        }
    }

}
