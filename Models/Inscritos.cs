namespace Models
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

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
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public int estado_id{ get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NumInscripcion { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        public virtual OfertaEmpleo OfertaEmpleo { get; set; }

        //LOGICA NEGOCIO
        public List<Inscritos> GetInscritos(int oferta_id, int estado)
        {
            var lista = new List<Inscritos>();
            var empresa_id = SesionHelper.GetUser();
            try
            {
                using (var bbdd= new ProyectoContexto())
                {
                    lista = bbdd.Inscritos.Include("Usuario")
                        .Where(i=>i.Oferta_id==oferta_id)
                        .Where(i=>i.Usuario_id_E==empresa_id)
                        .Where(i=>i.estado_id==estado)
                        .ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                return lista;
            }
        }
        public void SetModifiEstado(Int64 numIscripcion, int usuario_id, int estado_nuevo)
        {
            try
            {
                using(var bbdd= new ProyectoContexto())
                {
                    var inscripcion = bbdd.Inscritos
                        .Where(i => i.NumInscripcion == numIscripcion)
                        .Where(i=>i.Usuario_id_D==usuario_id)
                        .SingleOrDefault();
                    inscripcion.estado_id = estado_nuevo;
                    bbdd.Entry(inscripcion).State = EntityState.Modified;
                    bbdd.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Inscritos GetInscripcion (Int64 numIscripcion)
        {
            Inscritos inscrito = null;
            try
            {
                using(var bbdd= new ProyectoContexto())
                {
                    inscrito = bbdd.Inscritos.Include("Usuario")
                        .Where(i => i.NumInscripcion == numIscripcion).SingleOrDefault();
                }
                return inscrito;
            }
            catch (Exception)
            {

                return inscrito;
            }
        }

    }
}
