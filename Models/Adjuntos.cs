namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adjuntos
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        [Required]
        [StringLength(100)]
        public string fichero { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
