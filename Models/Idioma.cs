using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Idioma")]
    public partial class Idioma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Usuario_id { get; set; }
        public int Idiomas_id { get; set; }
        [Required]
        [StringLength(20)]
        public string Hablado { get; set; }
        [Required]
        [StringLength(20)]
        public string Escrito { get; set; }

        public virtual Idiomas Idiomas { get; set; }
        public virtual Usuario Usuario { get; set; }

        //LOGICA DE NEGOCIO
        public List<Idioma> GetIdiomas(int usuario_id)
        {
            var idiomas = new List<Idioma>();
            try
            {
                using (var bbdd=new ProyectoContexto())
                {
                    idiomas = bbdd.Idioma.Include("Idiomas").Where(i => i.Usuario_id == usuario_id).ToList();
                }
            }
            catch (Exception)
            {

                return idiomas;
            }
            return idiomas;
        }
        public Idioma GetIdioma (int id, int usuario_id)
        {
            Idioma idioma = null;
            try
            {
                using (var bbdd= new ProyectoContexto())
                {
                    idioma = bbdd.Idioma.Include("Idiomas").Where(i => i.id == id).Where(i=>i.Usuario_id==usuario_id).SingleOrDefault();
                }
            }
            catch (Exception)
            {

                return idioma;
            }
            return idioma;
        }
        public List<Idioma> GetMiIdioma(int idioma_id)
        {
            int usuario_id = SesionHelper.GetUser();
            var miIdioma = new List<Idioma>();
            try
            {
                using(var bbdd= new ProyectoContexto())
                {
                    miIdioma = bbdd.Idioma.Include("Idiomas")
                        .Where(i => i.Idiomas_id == Idiomas_id)
                        .Where(i => i.Usuario_id == usuario_id).ToList();
                    return miIdioma;
                }
            }
            catch (Exception)
            {

                return miIdioma;
            }
        }


    }

}
