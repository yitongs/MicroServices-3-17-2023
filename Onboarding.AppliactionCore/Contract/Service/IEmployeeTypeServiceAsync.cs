using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Model.Request;
using Onboarding.ApplicationCore.Model.Response;

namespace Onboarding.AppliactionCore.Contract.Service
{
    public interface IEmployeeTypeServiceAsync
    {
        Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> DeleteEmployeeTypeAsync(int id);
        Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id);
        Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypeAsync();
    }
}
