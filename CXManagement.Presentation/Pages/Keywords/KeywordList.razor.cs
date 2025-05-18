using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Presentation.Services.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public class KeywordListBase : ComponentBase
{
    [Inject] public KeywordService KeywordService { get; set; } = default!;
    [Inject] public IJSRuntime JSRuntime { get; set; } = default!;

    protected IEnumerable<KeywordDto> Keywords { get; set; } = new List<KeywordDto>();
    protected bool IsLoading { get; set; } = true;
    protected bool LoadError { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Keywords = await KeywordService.GetAllAsync();
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

    public async Task DeleteKeywordAsync(int id)
    {
        var confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete Keyword ID {id}?");
        if (!confirmed) return;

        try
        {
            await KeywordService.DeleteAsync(id);
            Keywords = Keywords.Where(k => k.CXKeywordID != id).ToList();
            StateHasChanged();
        }
        catch
        {
            LoadError = true;
        }
    }
}
