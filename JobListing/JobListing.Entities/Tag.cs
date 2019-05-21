using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Entities
{
    public class Tag
    {
        public Tag()
        {
            this.Jobs = new HashSet<Job>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
