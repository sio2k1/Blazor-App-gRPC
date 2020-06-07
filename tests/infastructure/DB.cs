using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB701BalzorApp.infastructure
{
    public class DB
    {
        public static List<AucRecord> lst = new List<AucRecord>();
    }


    public class AucRecord
    {
        public string name { get; set; }
        public string user { get; set; }
        public string category { get; set; }
        public double price { get; set; }
        public float currentBid { get; set; }
        public string userBid { get; set; }
        public int size { get; set; }
        public int id { get; set; }

    }
}
