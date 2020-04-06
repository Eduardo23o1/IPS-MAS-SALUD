using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contributivo
    {
        const double SALARIOMINIMO = 900000;
        public void LiquidarContributivo(Liquidación liquidacion)
        {
            if (liquidacion.TipoAfiliacion.Equals("RC"))
            {
                if (liquidacion.SalarioDevengado < SALARIOMINIMO * 2)
                {
                    double Tarifa = 15;
                    liquidacion.CuotaModeradora = liquidacion.ValorServicioHospitalizacion * Tarifa / 100;
                    double TOPE = 250000;
                    if (liquidacion.CuotaModeradora > TOPE)
                    {
                        liquidacion.CuotaModeradora = TOPE;
                        liquidacion.Tope = "SI";
                    }
                    else
                    {
                        liquidacion.Tope = "NO";
                    }
                    liquidacion.Tarifa = Tarifa;

                }

                if (liquidacion.SalarioDevengado >= SALARIOMINIMO * 2 && liquidacion.SalarioDevengado <= SALARIOMINIMO * 5)
                {
                    double Tarifa = 20;
                    liquidacion.CuotaModeradora = liquidacion.ValorServicioHospitalizacion * Tarifa / 100;
                    double TOPE = 900000;
                    if (liquidacion.CuotaModeradora > TOPE)
                    {
                        liquidacion.CuotaModeradora = TOPE;
                        liquidacion.Tope = "SI";
                    }
                    else
                    {
                        liquidacion.Tope = "NO";
                    }
                    liquidacion.Tarifa = Tarifa;
                }

                if (liquidacion.SalarioDevengado > SALARIOMINIMO * 5)
                {
                    double Tarifa = 25;
                    liquidacion.CuotaModeradora = liquidacion.ValorServicioHospitalizacion * Tarifa / 100;
                    double TOPE = 1500000;
                    if (liquidacion.CuotaModeradora > TOPE)
                    {
                        liquidacion.CuotaModeradora = TOPE;
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
}
