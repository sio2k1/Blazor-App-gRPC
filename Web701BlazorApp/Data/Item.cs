using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web701BlazorApp.Data
{
    public class Item // data class to represent and validate auction item
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public float BuyOutPrice { get; set; }
        [Required]
        [StringLength(255)]
        public string Category { get; set; }
        public float CurrentBid { get; set; }
        [Required]
        [Range(1, 15)]
        public int Size { get; set; }
        public int ClientUserRecordID { get; set; }
        public string ClientName { get; set; }
        public string SupplierName { get; set; }
        [Required]
        [Range(1, 10000)]
        public float Quantity { get; set; }
        public int MemberUserRecordID { get; set; }
        
    }
}



