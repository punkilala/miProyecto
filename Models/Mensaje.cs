namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mensaje")]
    public partial class Mensaje
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Remitente { get; set; }

        [Column("Mensaje", TypeName = "text")]
        [Required]
        public string Mensaje1 { get; set; }

        public DateTime Fecha { get; set; }

        public int Estado_id { get; set; }

        [StringLength(50)]
        public string relacion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
