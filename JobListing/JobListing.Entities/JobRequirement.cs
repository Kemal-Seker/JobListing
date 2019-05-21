using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Entities
{
    public class JobRequirement
    {
        [Key]
        public int RequirementId { get; set; }
        public string Requirement { get; set; }
        public int JobId { get; set; }
        public RequirementNatures RequirementNature { get; set; }

        public virtual Job Job { get; set; }
    }
}
