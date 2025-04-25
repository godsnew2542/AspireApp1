using Model.Entity;
using AspireApp1.Web.ServicesApi;

namespace AspireApp1.Web.Components.Pages;

public partial class Home
{
    private Api apiBackEnd { get; } = new();
    private List<ResumeCustomer> resumes { get; set; } = new();
    private string? text { get; set; } = null;
    private bool isLoading { get; set; } = true;

    protected override void OnInitialized()
    {
        text = "test OnInitialized";
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            isLoading = true;
            try
            {
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
