using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web701BlazorApp.Data
{
    public class CardModel //card data class for displaying cards (articles, growers)
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageLink { get; set; }
    }
}
