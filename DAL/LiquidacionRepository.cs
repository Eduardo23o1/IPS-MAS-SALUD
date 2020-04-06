using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
namespace DAL
{
    public class LiquidacionRepository
    {
        private string ruta = @"Liquidacion.txt";
        private List<Liquidación> liquidaciones;
        public LiquidacionRepository()
        {
            liquidaciones = new List<Liquidación>();
        }
        public void Guardar(Liquidación liquidacion)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(liquidacion.ToString());
            writer.Close();
            fileStream.Close();
        }
        public List<Liquidación> Consultar()
        {
            liquidaciones.Clear();
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            string linea = string.Empty;
            while ((linea = streamReader.ReadLine()) != null)
            {
                Liquidación liquidacion = new Liquidación();
                string[] datos = linea.Split(';');
                liquidacion.NumeroLiquidacion = datos[0];
                liquidacion.Identificacion = datos[1];
                liquidacion.Nombre = datos[2];
                liquidacion.TipoAfiliacion = datos[3];
                liquidacion.SalarioDevengado = double.Parse(datos[4]);
                liquidacion.ValorServicioHospitalizacion = double.Parse(datos[5]);
                liquidacion.CuotaModeradora = double.Parse(datos[6]);
                liquidacion.Tarifa = double.Parse(datos[7]);
                liquidacion.Tope = datos[8];
                liquidaciones.Add(liquidacion);
            }
            fileStream.Close();
            streamReader.Close();
            return liquidaciones;
        }

        public void Eliminar(string numeroLiquidacion)
        {
            liquidaciones.Clear();
            liquidaciones = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in liquidaciones)
            {
                if (item.NumeroLiquidacion != numeroLiquidacion)
                {
                    Guardar(item);
                }
            }
        }
        public Liquidación Buscar(string numeroLiquidacion)
        {
            liquidaciones.Clear();
            liquidaciones = Consultar();
            Liquidación liquidacion = new Liquidación();
            foreach (var item in liquidaciones)
            {
                if (item.NumeroLiquidacion.Equals(numeroLiquidacion))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
