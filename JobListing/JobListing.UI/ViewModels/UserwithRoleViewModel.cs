using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobListing.UI.ViewModels
{
    public class UserwithRoleViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<UserViewModel> Admins { get; set; }
    }
}