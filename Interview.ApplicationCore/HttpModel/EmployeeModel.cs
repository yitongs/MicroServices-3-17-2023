using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.ApplicationCore.HttpModel
{
    public class EmployeeModel
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
    }
}
