using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Onboarding.ApplicationCore.Model.Request
{ 
    public class EmployeeRequestModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string SSN { get; set; }

   
        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime EndDate { get; set; }
        public EmployeeRoleRequestModel? EmployeeRole { get; set; }

        public EmployeeTypeRequestModel? EmployeeType { get; set; }

        public EmployeeStatusRequestModel? EmployeeStatus { get; set; }

    }
}
