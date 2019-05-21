using JobListing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobListing.UI.ViewModels
{
    public class JobViewModel
    {
        public Job job { get; set; }
        public IEnumerable<Company> companies { get; set; }
    }
}