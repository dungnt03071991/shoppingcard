using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VPExam.Models;

namespace VPExam.DBContext
{
    public partial class Items : DbContext
    {
        public Items()
            : base("name=Items")
        {
            this.Database.CommandTimeout = 50;
        }
        public virtual DbSet<Item> ItemsDetails { get; set; }
        public virtual DbSet<Cart> CartsDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}