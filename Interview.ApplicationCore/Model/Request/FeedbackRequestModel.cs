using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Interview.ApplicationCore.Model.Request
{
    public class FeedbackRequestModel
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
