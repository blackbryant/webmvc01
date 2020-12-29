namespace WebMVC01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public string Description { get; set; }
    }
}
