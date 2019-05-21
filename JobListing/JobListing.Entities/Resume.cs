using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Entities
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public byte[] File { get; set; }
        public DateTime ValidityStartDate { get; set; }
        public DateTime? ValidityEndDate { get; set; }
    }
}
