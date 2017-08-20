namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Social")]
    public partial class Social
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string url { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
