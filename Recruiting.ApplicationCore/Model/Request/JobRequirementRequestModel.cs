using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Recruiting.ApplicationCore.Model.Request
{
    public class JobRequirementRequestModel
    {
        public int Id { get; set; }

       
        public string Title { get; set; }

        public string Description { get; set; }
        public int NumberOfPositions { get; set; }

        public int HiringManagerId { get; set; }

        public string HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ClosedOn { get; set; }

        public string ClosedReason { get; set; }
        public DateTime CreateOn { get; set; }
        public bool IsActive { get; set; }
        public int JobCategory { get; set; }
        public int EmployeeType { get; set; }
    }
}
