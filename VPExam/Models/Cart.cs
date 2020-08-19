namespace VPExam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Carts")]
    public partial class Cart
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
    }
}
