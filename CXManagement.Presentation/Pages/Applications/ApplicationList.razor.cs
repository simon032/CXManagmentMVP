using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Presentation.Services.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public partial class ApplicationListBase : ComponentBase
{
    [Inject]
    public ApplicationService ApplicationService { get; set; }
    [Inject] public IJSRuntime JSRuntime { get; set; }

    protected IEnumerable<ApplicationDto> Applications { get; set; }
    protected bool IsLoading { get; set; } = true;
    protected bool LoadError { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Applications = await ApplicationService.GetAllApplicationsAsync();
        }
        catch
        {
            LoadError = true;
        }
        finally
        {
            IsLoading = false;
        }
    }
    public async Task DeleteApplicationAsync(int id)
    {
        var confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete Application ID {id}?");
        if (!confirmed) return;

        var success = await ApplicationService.DeleteApplicationAsync(id);
        if (success)
        {
            Applications = Applications.Where(app => app.CXAID != id).ToList();
            StateHasChanged();
        }
        else
        {
            LoadError = true;
        }
    }
}
