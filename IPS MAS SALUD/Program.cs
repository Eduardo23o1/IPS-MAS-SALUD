using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace IPS_MAS_SALUD
{
    class Program
    {
        static void Main(string[] args)
        {
            LiquidacionService service = new LiquidacionService();
            Guardar(service);
            ConsultaGeneral(service);
        }
        private static void Guardar(LiquidacionService service)
        {
            string numeroLiquidacion, identificacion, nombre, tipoAfiliacion;
            double salarioDevengado, valorServicioHospitalizacion;
            Console.Write("Digite numero de liquidacion: ");
            numeroLiquidacion = Console.ReadLine();

            Console.Write("Digite identificacion: ");
            identificacion = Console.ReadLine();

            Console.Write("Digite nombre: ");
            nombre = Console.ReadLine();

            Console.Write("Digite tipo de afiliacion: ");
            tipoAfiliacion = Console.ReadLine();

            Console.Write("Digite salario devengado: ");
            salarioDevengado = double.Parse(Console.ReadLine());

            Console.Write("Digite valor servicio de hospitalizacion: ");
            valorServicioHospitalizacion = double.Parse(Console.ReadLine());
            Liquidación liquidacion = new Liquidación()
            {
                NumeroLiquidacion = numeroLiquidacion,
                Identificacion = identificacion,
                Nombre = nombre,
                TipoAfiliacion = tipoAfiliacion,
                SalarioDevengado = salarioDevengado,
                ValorServicioHospitalizacion = valorServicioHospitalizacion
            };

            service.calcular(liquidacion);
            string mensaje = service.Guardar(liquidacion);
            Console.Write(mensaje);
            Console.WriteLine(liquidacion.ToString());
            Console.ReadKey();
        }new
        private static void ConsultaGeneral(LiquidacionService service)
        {
            Console.Clear();
            RespuestaConsulta respuestaConsulta = service.ConsultarConsultaGeneral();
            Console.WriteLine(respuestaConsulta.Mensaje);
            if (!respuestaConsulta.Error)
            {
                foreach (var item in respuestaConsulta.liquidaciones)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
