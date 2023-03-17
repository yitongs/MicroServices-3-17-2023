using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Interview.ApplicationCore.Entity
{
    public class Feedback
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Comment { get; set; }
    }
}
