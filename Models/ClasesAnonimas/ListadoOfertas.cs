using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ClasesAnonimas
{
    public class ListadoOfertas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public bool Abierta { get; set; }
        public int Cuenta { get; set; }

    }
}
