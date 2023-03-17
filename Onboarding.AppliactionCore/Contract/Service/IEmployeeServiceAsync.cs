using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Model.Request;
using Onboarding.ApplicationCore.Model.Response;

namespace Onboarding.AppliactionCore.Contract.Service
{
    public interface IEmployeeServiceAsync
    {
        Task<int> AddEmployeeAsync(EmployeeRequestModel model);
        Task<int> UpdateEmployeeAsync(EmployeeRequestModel model);

        Task<int> DeleteEmployeeAsync(int id);

        Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeeAsync();
    }
}
