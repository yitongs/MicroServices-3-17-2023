using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Onboarding.ApplicationCore.Model.Response
{ 
    public class EmployeeResponseModel
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
        public EmployeeRoleResponseModel? EmployeeRole { get; set; }

        public EmployeeTypeResponseModel? EmployeeType { get; set; }

        public EmployeeStatusResponseModel? EmployeeStatus { get; set; }

    }
}
