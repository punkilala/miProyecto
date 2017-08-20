namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Conocimiento")]
    public partial class Conocimiento
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        [Required]
        [StringLength(70)]
        public string Nombre { get; set; }

        public int Nivel { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
