using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboarding.AppliactionCore.Contract.Repository;
using Onboarding.ApplicationCore.Entity;
using Onboarding.Infrastruction.Data;

namespace Onboarding.Infrastruction.Repository
{
    public class EmployeeStatusRepositoryAsync : BaseRepositoryAsync<EmployeeStatus>, IEmployeeStatusRepositoryAsync
    {
        public EmployeeStatusRepositoryAsync(OnboardingDbContext _context) : base(_context)
        {
        }
    }
}
