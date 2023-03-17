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
    public class EmployeeServiceAsync: IEmployeeServiceAsync
    {
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;

        public EmployeeServiceAsync(IEmployeeRepositoryAsync _employeeRepositoryAsync)
        {
            employeeRepositoryAsync = _employeeRepositoryAsync;
        }

        public Task<int> AddEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Email = model.Email,
                SSN = model.SSN,
                Address = model.Address,
                HireDate = model.HireDate,
                EndDate = model.EndDate
                //EmployeeRole = model.EmployeeRole,
                //EmployeeStatus = model.EmployeeStatus,
                //EmployeeType = model.EmployeeType

            };
            return employeeRepositoryAsync.InsertAsync(employee);
        }

        public Task<int> DeleteEmployeeAsync(int id)
        {
            return employeeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeeAsync()
        {
            var result = await employeeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeResponseModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    Email = x.Email,
                    SSN = x.SSN,
                    Address = x.Address,
                    HireDate = x.HireDate,
                    EndDate = x.EndDate

                });
            }
            return null;
        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var result = await employeeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    MiddleName = result.MiddleName,
                    Email = result.Email,
                    SSN = result.SSN,
                    Address = result.Address,
                    HireDate = result.HireDate,
                    EndDate = result.EndDate

                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Email = model.Email,
                SSN = model.SSN,
                Address = model.Address,
                HireDate = model.HireDate,
                EndDate = model.EndDate

            };
            return employeeRepositoryAsync.UpdateAsync(employee);
        }
    }
}
