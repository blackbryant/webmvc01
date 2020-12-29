namespace WebMVC01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductHolding
    {
        [Key]
        public int ProductID { get; set; }

        public int? Quantity { get; set; }

        public int? ReorderLevel { get; set; }
    }
}
