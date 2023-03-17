using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Onboarding.ApplicationCore.Model.Request
{
    public class EmployeeStatusRequestModel
    {
        public int Id { get; set; }

        public string ABBR { get; set; }

        public string Description { get; set; }

    }
}
