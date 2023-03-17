using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Recruiting.ApplicationCore.Entity
{
    public class JobRequirement
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }   

        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public int NumberOfPositions { get; set; }

        public int HiringManagerId { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ClosedOn { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ClosedReason { get; set; }
        public DateTime CreateOn { get; set; }
        public bool IsActive { get; set; }

        public int JobCategory { get; set; }

        public int EmployeeType { get; set; }
    }

}
