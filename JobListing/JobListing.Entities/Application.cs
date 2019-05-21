using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Entities
{
    [Table("Application")]
    public class Application
    {
        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        public int ApplicantId { get; set; }
        public int ResumeId { get; set; }
        public DateTime ApplicationDate { get; set; }

        public virtual Job Job { get; set; }
        public virtual Applicant Applicant { get; set; }
        public virtual Resume Resume { get; set; }
    }
}
