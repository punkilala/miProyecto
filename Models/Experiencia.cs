namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Experiencia")]
    public partial class Experiencia
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        public byte Tipo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Desde { get; set; }

        [Column(TypeName = "date")]
        public DateTime Hasta { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descripcion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
