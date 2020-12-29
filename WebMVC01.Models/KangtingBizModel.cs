namespace WebMVC01.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KangtingBizModel : DbContext
    {
        public KangtingBizModel()
            : base("name=KangtingBizConn")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductHolding> ProductHoldings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
