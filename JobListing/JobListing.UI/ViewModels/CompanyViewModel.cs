using JobListing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobListing.UI.ViewModels
{
    public class CompanyViewModel
    {
        public Company company { get; set; }
        public IEnumerable<City> cities { get; set; }

    }
}