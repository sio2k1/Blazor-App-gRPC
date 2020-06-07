using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB701BalzorApp.Auth
{
    public class User
    {
        public int id { get; set; }
        public string uLogin { get; set; }
        public string uRole { get; set; }
        public string uPassword { get; set; }
        public string uName { get; set; }
    }
}
