namespace QBisnis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FixedCost")]
    public partial class FixedCost
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Kategori { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Nominal { get; set; }

        [Required]
        [StringLength(200)]
        public string Note { get; set; }
    }
}
