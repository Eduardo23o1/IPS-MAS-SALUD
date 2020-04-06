using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Subsidiado
    {
        public void LiquidarSubsidiado(Liquidación liquidacion)
        {
            double Tarifa = 5;
            if (liquidacion.TipoAfiliacion.Equals("RS"))
            {
                liquidacion.CuotaModeradora = liquidacion.ValorServicioHospitalizacion * Tarifa / 100;
                double Tope = 200000;
                if (liquidacion.CuotaModeradora > Tope)
                {
                    liquidacion.CuotaModeradora = Tope;
                    liquidacion.Tope = "SI";
                }
                else
                {
                    liquidacion.Tope = "NO";
                }
                liquidacion.Tarifa = Tarifa;
            }
        }
    }
}
