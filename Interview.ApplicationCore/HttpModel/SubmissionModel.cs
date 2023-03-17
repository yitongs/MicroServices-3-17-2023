using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.ApplicationCore.HttpModel
{
    public class SubmissionModel
    {
        public int Id { get; set; }
        public DateTime SubmittedOn { get; set; }

        public DateTime ConfirmedOn { get; set; }

        public DateTime RejectedOn { get; set; }

    }
}
