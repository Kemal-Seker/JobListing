using JobListing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobListing.UI.ViewModels
{
    public class JobCityViewModel
    {
        public City city { get; set; }
        public IEnumerable<Job> jobs { get; set; }

    }
}