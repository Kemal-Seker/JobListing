using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Entities
{
    [Table("City")]
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

    }
}
