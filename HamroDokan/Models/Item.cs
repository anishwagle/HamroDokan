using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HamroDokan.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string IteamArtUr { get; set; }
        public List<string> Keywords { get; set; }
        public Category Category { get; set; }
        public Producer Producer { get; set; }
    }
}