using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Recruiting.ApplicationCore.Entity
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }
        
        [Column(TypeName = "varchar(20)")]
        public string MiddleName { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }

        [Required]

        [Column(TypeName = "varchar(70)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? ResumeUrl { get; set; }
    }
}
