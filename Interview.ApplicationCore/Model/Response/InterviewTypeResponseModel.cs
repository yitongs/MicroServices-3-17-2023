using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Interview.ApplicationCore.Model.Response
{
    public class InterviewTypeResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

    }
}
