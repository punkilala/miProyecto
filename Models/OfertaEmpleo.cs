namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OfertaEmpleo")]
    public partial class OfertaEmpleo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfertaEmpleo()
        {
            Inscritos = new HashSet<Inscritos>();
        }

        public int id { get; set; }

        public int Usuario_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string RequisitosMin { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ExperienciaMin { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descripcion { get; set; }

        public int Categoria_id { get; set; }

        public int Vacantes { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? Salario { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inscritos> Inscritos { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
