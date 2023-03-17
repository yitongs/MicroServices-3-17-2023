using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboarding.AppliactionCore.Contract.Repository;
using Onboarding.AppliactionCore.Contract.Service;
using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Model.Request;
using Onboarding.ApplicationCore.Model.Response;

namespace Onboarding.Infrastruction.Service
{
    public class EmployeeTypeServiceAsync : IEmployeeTypeServiceAsync
    {
        private readonly IEmployeeTypeRepositoryAsync employeeTypeRepositoryAsync;

        public EmployeeTypeServiceAsync(IEmployeeTypeRepositoryAsync _employeeTypeRepositoryAsync)
        {
            employeeTypeRepositoryAsync = _employeeTypeRepositoryAsync;
        }
        public Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            EmployeeType employeeType = new EmployeeType()
            {
                
                Description = model.Description

            };
            return employeeTypeRepositoryAsync.InsertAsync(employeeType);
        }

        public Task<int> DeleteEmployeeTypeAsync(int id)
        {
            return employeeTypeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypeAsync()
        {
            var result = await employeeTypeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeTypeResponseModel()
                {
                    Id = x.Id,
                    Description = x.Description
                });
            }
            return null;
        }

        public async Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id)
        {
            var result = await employeeTypeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeTypeResponseModel()
                {
                    Id = result.Id,
                    Description = result.Description

                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {

            EmployeeType employeeType = new EmployeeType()
            {
                Id = model.Id,
                Description = model.Description
            };
            return employeeTypeRepositoryAsync.UpdateAsync(employeeType);


        }
    }
}
