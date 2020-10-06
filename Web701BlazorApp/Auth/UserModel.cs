using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB701BalzorApp.Auth
{
    public class UserModel //user data class
    {
        public int id { get; set; }
        public string uLogin { get; set; }
        public string uRole { get; set; }
        public string uPassword { get; set; }
        public string uName { get; set; }
        public string uDescrtiption { get; set; }
        public string uToken { get; set; }
    }
}
