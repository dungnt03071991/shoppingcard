namespace VPExam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Items")]
    public partial class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
