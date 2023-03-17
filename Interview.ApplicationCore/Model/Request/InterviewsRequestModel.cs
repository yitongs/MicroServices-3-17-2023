using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Entity;

namespace Interview.ApplicationCore.Model.Request
{
    public class InterviewsRequestModel
    {
        public int Id { get; set; }
        public  int SubmissionId { get; set; }
        public Recruiter Recruiter { get; set; }
        public DateTime ScheduledOn { get; set; }
        public int InterviewRound { get; set; }     
        public Feedback Feedback { get; set; }
        public InterviewType InterviewType { get; set; }
        public Interviewer Interviewer { get; set; }

    }
}
