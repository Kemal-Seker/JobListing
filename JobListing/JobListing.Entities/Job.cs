using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Entities
{
    public class Job
    {
        public Job()
        {
            this.Tags = new HashSet<Tag>();
            this.Categories = new HashSet<Category>();
        }

        public int JobId { get; set; }
        public string Title { get; set; }
        public JobNatures JobNature { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public string JobDescriptionTitle { get; set; }
        public string JobDescriptionBody { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
       
    }
}
