using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Repository;
using Onboarding.ApplicationCore.Entity;
namespace Onboarding.AppliactionCore.Contract.Repository
{
    public interface IEmployeeStatusRepositoryAsync: IRepositoryAsync<EmployeeStatus>
    {
    }
}
