using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Onboarding.ApplicationCore.Entity
{ 
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string MiddleName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(9)")]
        public string SSN { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime EndDate { get; set; }
        public EmployeeRole? EmployeeRole { get; set; }

        public EmployeeType? EmployeeType { get; set; }

        public EmployeeStatus? EmployeeStatus { get; set; }

    }
}
