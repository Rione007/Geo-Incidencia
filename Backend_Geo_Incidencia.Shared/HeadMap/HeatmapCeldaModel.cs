using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Geo_Incidencia.Shared.HeadMap
{
    public class HeatmapCeldaModel
    {
        public int Cantidad { get; set; }
        public decimal CentroLat { get; set; }
        public decimal CentroLng { get; set; }
    }
}
