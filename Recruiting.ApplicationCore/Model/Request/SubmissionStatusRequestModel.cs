using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Recruiting.ApplicationCore.Model.Request
{
    public class SubmissionStatusRequestModel
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
