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

    [Table("OfertaEmpleo")]
    public partial class OfertaEmpleo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfertaEmpleo()
        {
            Inscritos = new HashSet<Inscritos>();
        }

        public int id { get; set; }

        [Required]
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

        [Required]
        public int Vacantes { get; set; }

        public int Salario { get; set; }
        public string  Pago { get; set; }
        public string ModoPago { get; set; }


        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
        public bool  Abierta { get; set; }

        public virtual Categoria Categoria { get; set; }

        public DateTime? FechaGestion { get; set; }
        public virtual ICollection<Inscritos> Inscritos { get; set; }

        public virtual Usuario Usuario { get; set; }

        // LOGICA DE NEGOCIO

        public List<OfertaEmpleo> GetLista(Filtro filtro)
        {
            int usuario_id = SesionHelper.GetUser();
            var lista = new List<OfertaEmpleo>();
            try
            {
                using (var bbdd = new ProyectoContexto())
                {
                    lista = bbdd.OfertaEmpleo.Include("Inscritos").Where(oe => oe.Usuario_id == usuario_id)
                        .OrderByDescending(oe=>oe.Fecha).ToList();

                    if (filtro.numeroOrderBy=="Desc") lista = lista.OrderByDescending(x => x.id).ToList();
                    if (filtro.numeroOrderBy == "Asc") lista = lista.OrderBy(x => x.id).ToList();
                    if (filtro.nombreOrderBy=="Desc") lista = lista.OrderByDescending(x => x.Nombre).ToList();
                    if (filtro.nombreOrderBy == "Asc") lista = lista.OrderBy(x => x.Nombre).ToList();
                    if (filtro.desdeOrderBy == "Desc") lista = lista.OrderByDescending(x => x.Fecha).ToList();
                    if (filtro.desdeOrderBy == "Asc") lista = lista.OrderBy(x => x.Fecha).ToList();
                    if (filtro.inscritosOrderBy == "Desc") lista = lista.OrderByDescending(x => x.Inscritos.Count()).ToList();
                    if (filtro.inscritosOrderBy == "Asc") lista = lista.OrderBy(x => x.Inscritos.Count()).ToList();
                    if (filtro.Estado=="false")
                        lista = lista.Where(x => x.Abierta == false).ToList();
                    else
                        lista = lista.Where(x => x.Abierta == true).ToList();
                    if (filtro.porNombre!= null)
                        lista = lista.Where(x => x.Nombre.Contains(filtro.porNombre)).ToList();
                    if (filtro.porTitulo != null)
                    {
                        int num;
                        int.TryParse(filtro.porTitulo, out num);
                        lista = lista.Where(x => x.id.Equals(num)).ToList();

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                return lista;
            }
        }
        public OfertaEmpleo GetOferta (int id)
        {
            int usuario_id = SesionHelper.GetUser();
            var oferta = new OfertaEmpleo();
            try
            {
                using (var bbdd= new ProyectoContexto())
                {
                    oferta = bbdd.OfertaEmpleo.Where(oe => oe.id == id).Where(oe => oe.Usuario_id == usuario_id).SingleOrDefault();
                    //registrar la ultma vez que se entra a ver la oferta por parte de la empresa
                    if (oferta != null)
                    {
                        oferta.FechaGestion = DateTime.Now;
                        bbdd.Entry(oferta).State = EntityState.Modified;
                        bbdd.SaveChanges();
                    }
                }
                return oferta;
            }
            catch (Exception)
            {

                return oferta;
            }
        }
        public bool SetOferta()
        {
            bool result = false;
            try
            {
                using(var bbdd=new ProyectoContexto())
                {
                    if (this.id == 0)
                    {
                        bbdd.Entry(this).State = EntityState.Added;
                    }
                    else
                    {
                        var oe = bbdd.Entry(this);
                        bbdd.Entry(this).State = EntityState.Modified;
                        
                    }
                    bbdd.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {

                return false;
            }
        }
        public void CambiarEstado(int id)
        {
            try
            {
                using(var bbdd= new ProyectoContexto())
                {
                    var oferta = bbdd.OfertaEmpleo.Where(o => o.id == id).SingleOrDefault();
                    oferta.Abierta= oferta.Abierta ? false : true;
                    bbdd.Entry(oferta).State = EntityState.Modified;
                    bbdd.SaveChanges();

                    //actualizar InscritosHistorial
                    //notificar a todos los inscritos que se ha cerrado el proceso de seleccion
                    var lista = new List<Inscritos>();
                    Inscritos inscritos = new Inscritos();
                    lista = inscritos.GetInscritos(id);
                    InscritosHistorial historial = new InscritosHistorial();
                    foreach (var item in lista)
                    {
                        historial.SetHistorial(item.Usuario_id_D, item.Oferta_id, 31);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
