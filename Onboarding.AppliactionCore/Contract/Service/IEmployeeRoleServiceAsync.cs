using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Model.Request;
using Onboarding.ApplicationCore.Model.Response;

namespace Onboarding.AppliactionCore.Contract.Service
{
    public interface IEmployeeRoleServiceAsync
    {
        Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model);
        Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model);
        Task<int> DeleteEmployeeRoleAsync(int id);
        Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id);
        Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoleAsync();
    }
}
