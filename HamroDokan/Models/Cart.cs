﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HamroDokan.Models
{
    public class Cart
    {
        
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Item Item { get; set; }


    }
}