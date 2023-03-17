using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onboarding.ApplicationCore.Entity;

namespace Onboarding.Infrastruction.Data
{
    public class OnboardingDbContext: DbContext
    {
        public OnboardingDbContext(DbContextOptions<OnboardingDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<EmployeeRole> EmployeeRole { get; set; }

        public DbSet<EmployeeStatus> EmployeeStatus { get; set; }
        public DbSet<EmployeeType> EmployeeType { get; set; }



    }
}
