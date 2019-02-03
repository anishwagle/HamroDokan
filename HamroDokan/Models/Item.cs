using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HamroDokan.Models
{
    [Bind(Exclude = "IteamId")]
    public class Item
    {
        [ScaffoldColumn(false)]
        public int ItemId { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [DisplayName("Producer")]
        public int ProducerId { get; set; }
        [Required(ErrorMessage ="An Iteam Title is Required")]
        [StringLength(160)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Price Is Required")]
        public decimal Price { get; set; }
        [DisplayName("ImagePath")]
        public string ItemArtUrl { get; set; }
        public List<string> Keywords { get; set; }
        public virtual Category Category { get; set; }
        public virtual Producer Producer { get; set; }
    }
}