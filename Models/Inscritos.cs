namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inscritos
    {
        public int Usuario_id_E { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Usuario_id_D { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Oferta_id { get; set; }

        [Required]
        [StringLength(50)]
        public string relacion { get; set; }

        public int estado { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NumInscripcion { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        public virtual OfertaEmpleo OfertaEmpleo { get; set; }
    }
}
