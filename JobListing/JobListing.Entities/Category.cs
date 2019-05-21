using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Entities
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            this.Jobs = new HashSet<Job>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
