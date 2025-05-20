using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.DTOs.CX_Customer;
using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.DTOs.CX_Keyword;
using CXManagement.Presentation.Presenters;
using CXManagement.Presentation.Views.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CXManagement.Presentation.Pages.Customers
{
    public class CustomerListBase : ComponentBase, ICustomerView
    {
        [Inject] protected CustomerPresenter Presenter { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        protected List<CustomerDto> Customers { get; set; } = new();
        protected bool IsLoading { get; set; } = true;
        protected bool LoadError { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Presenter.SetView(this);
            await Presenter.LoadCustomersAsync();
        }

        public void ShowCustomers(IEnumerable<CustomerDto> customers)
        {
            Customers = customers.ToList();
            IsLoading = false;
            LoadError = false;
            StateHasChanged();
        }

        public void ShowCustomer(CustomerDto customer)
        {
            // Not used in the list view
        }

        public void ShowError(string message)
        {
            LoadError = true;
            IsLoading = false;
            StateHasChanged();
        }

        protected async Task DeleteCustomerAsync(int id)
        {
            var confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete Customer ID {id}?");
            if (!confirmed) return;

            var success = await Presenter.DeleteCustomerAsync(id);
            if (success)
            {
                await Presenter.LoadCustomersAsync();
            }
            else
            {
                ShowError("Failed to delete customer.");
            }
        }

        public void ShowApplications(IEnumerable<ApplicationDto> applications)
        {
            throw new NotImplementedException();
        }

        public void ShowKeywords(IEnumerable<KeywordDto> applications)
        {
            throw new NotImplementedException();
        }

        public void ShowCustomerAppKeywordValueView(List<CustomerAppKeywordValueViewDto> dto)
        {
            throw new NotImplementedException();
        }
    }
}
