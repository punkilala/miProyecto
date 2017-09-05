using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("InscritosHistorial")]
    public partial class InscritosHistorial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Index]
        public int Usuario_id_D { get; set; }
        [Index]
        public int Oferta_id { get; set; }

        public int estado_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public virtual Inscritos Inscritos { get; set; }

        //LOGICA DE NEGOCIO
        public void SetHistorial(int usuario_id, int oferta_id, int estado_id)
        {
            try
            {
                using (var bbdd = new ProyectoContexto())
                {
                    var historial = new InscritosHistorial();
                    historial.Usuario_id_D = usuario_id;
                    historial.Oferta_id = oferta_id;
                    historial.estado_id = estado_id;
                    historial.Fecha = DateTime.Now;

                    bbdd.Entry(historial).State = EntityState.Added;
                    bbdd.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
