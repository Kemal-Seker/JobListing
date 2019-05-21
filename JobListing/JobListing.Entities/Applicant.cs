using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Entities
{
    [Table("Applicant")]
    public class Applicant
    {
        public int ApplicantId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public int ActiveResumeId { get; set; }
        [ForeignKey("ActiveResumeId")]
        public virtual Resume Resume { get; set; }
    }
}
