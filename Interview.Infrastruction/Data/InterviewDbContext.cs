using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Model.Request;

namespace Interview.Infrastruction.Data
{
    public class InterviewDbContext: DbContext
    {
        public InterviewDbContext(DbContextOptions<InterviewDbContext> options) : base(options)
        {

        }
        public DbSet<Interviews> Interviews { get; set; }

        public DbSet<Interviewer> Interviewer { get; set; }

        public DbSet<InterviewType> InterviewType { get; set; }
        public DbSet<Recruiter> Recruiter { get; set; }
        public DbSet<Feedback> Feedback { get; set; }



    }
}
