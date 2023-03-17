using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.ApplicationCore.Model.Request
{
    public class SubmissionRequestModel
    {
        public int Id { get; set; }
        public DateTime SubmittedOn { get; set; }

        public DateTime ConfirmedOn { get; set; }

        public DateTime RejectedOn { get; set; }

        public SubmissionStatus SubmissionStatus { get; set; }
        //navigational properties
        public Candidate Candidate { get; set; }
        public JobRequirement JobRequirement { get; set; }
    }
}
