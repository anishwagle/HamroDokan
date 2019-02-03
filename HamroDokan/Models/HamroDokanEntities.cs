using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HamroDokan.Models 
{
    public class HamroDokanEntities:DbContext
    {
        public HamroDokanEntities() : base("HamroDokanEntities")
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}