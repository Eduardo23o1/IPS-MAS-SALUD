using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Liquidación
    {
        public string NumeroLiquidacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string TipoAfiliacion { get; set; }
        public double SalarioDevengado { get; set; }
        public double ValorServicioHospitalizacion { get; set; }
        public double CuotaModeradora { get; set; }
        public double Tarifa { get; set; }
        public string Tope { get; set; }
        public override string ToString()
        {
            return $"{NumeroLiquidacion};{Identificacion};{Nombre};{TipoAfiliacion};{SalarioDevengado};{ValorServicioHospitalizacion};{CuotaModeradora};{Tarifa};{Tope}";
        }
    }
}
