namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Estado")]
    public partial class Estado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [StringLength(50)]
        public string Relacion { get; set; }
        
        //LOGICA DE NEGOCIO

        public List<Estado> GetNiveles()
        {
            var lista = new List<Estado>();
            try
            {
                using(var bbdd = new ProyectoContexto())
                {
                    lista = bbdd.Estado.Where(e => e.Relacion.Equals("idiomas")).ToList();
                    return lista;
                }
            }
            catch (Exception)
            {

                return lista;
            }
        }
    }

}
