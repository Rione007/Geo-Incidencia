using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Domain.Entities
{
    public class Respuesta
    {
        public int Id { get; set; }
        public Int32 Fila { get; set; }
        public Int32 Error { get; set; }
        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public Object objeto { get; set; }

        public Respuesta()
        {
            Id = 0;
            Fila = 0;
            Error = 0;
            Estado = "";
            Mensaje = "";
            Fecha = DateTime.Now;
            objeto = new Object();
        }
    }
}
