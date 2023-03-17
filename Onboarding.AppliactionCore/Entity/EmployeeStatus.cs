using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Onboarding.ApplicationCore.Entity
{
    public class EmployeeStatus
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(16)")]
        public string ABBR { get; set; }

        [Column(TypeName = "varchar(512)")]
        public string Description { get; set; }

    }
}
