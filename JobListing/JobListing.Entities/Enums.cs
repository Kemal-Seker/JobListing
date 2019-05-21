using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Entities
{
    public enum JobNatures
    {
        FullTime=0,
        PartTime=1,
        Intern=2
    }
    public enum RequirementNatures
    {
        Experience,
        JobFeature,
        Education
    }
}