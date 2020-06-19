using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web701BlazorApp.Data
{
    public class UserDetails // data class to represent and validate user details
    {
        [StringLength(255)]
        public string uName { get; set; }

    }
    public class GrowerDetails: UserDetails
    {
        [StringLength(255)]
        public string uDescription { get; set; }
    }
}
