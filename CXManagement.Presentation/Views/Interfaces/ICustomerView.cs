using CXManagement.Application.DTOs.CX_Application;
using CXManagement.Application.DTOs.CX_Customer;
using CXManagement.Application.DTOs.CX_Customer_AppKeyword_Value;
using CXManagement.Application.DTOs.CX_Keyword;

namespace CXManagement.Presentation.Views.Interfaces
{
    public interface ICustomerView
    {
        void ShowCustomers(IEnumerable<CustomerDto> customers);
        void ShowCustomer(CustomerDto customer);
        void ShowError(string message);
        void ShowApplications(IEnumerable<ApplicationDto> applications);
        void ShowKeywords(IEnumerable<KeywordDto> applications);
        void ShowCustomerAppKeywordValueView(List<CustomerAppKeywordValueViewDto> dto);

    }
}
