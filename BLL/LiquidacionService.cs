using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class LiquidacionService
    {
          
        private LiquidacionRepository cuotaRepository;
        private Subsidiado subsidiado;
        private Contributivo contributivo;
        public LiquidacionService()
        {
            cuotaRepository = new LiquidacionRepository();
            subsidiado = new Subsidiado();
            contributivo = new Contributivo();
        }

        
        public void calcular(Liquidación liquidacion)
        {
            subsidiado.LiquidarSubsidiado(liquidacion);
            contributivo.LiquidarContributivo(liquidacion);
        }
        public string Guardar(Liquidación liquidacion)
        {
            try
            {
                cuotaRepository.Guardar(liquidacion);
                return "Los Datos han sido guardados satisfactoriamente";
            }
            catch (Exception e)
            {

                return "Error de Datos: " + e.Message;
            }
        }
        public string Eliminar(string numeroLiquidacion)
        {
            try
            {
                if (cuotaRepository.Buscar(numeroLiquidacion) != null)
                {
                    cuotaRepository.Eliminar(numeroLiquidacion);
                    return $"se elimino la liquidacion numero: {numeroLiquidacion} correctamente";
                }
                return $"El numero de liquidacion no esta registrado en el sistema";
            }
            catch (Exception e)
            {
                return $"ERROR" + e.Message;
            }
        }
        public RespuestaConsulta ConsultarConsultaGeneral()
        {
            RespuestaConsulta respuesta = new RespuestaConsulta();
            try
            {
                respuesta.Error = false;
                respuesta.liquidaciones = cuotaRepository.Consultar();
                if (respuesta.liquidaciones != null)
                {
                    respuesta.Mensaje = "LISTADO DE LIQUIDACIONES";
                }
                else
                {
                    respuesta.Mensaje = "NO HAY DATOS";
                }
            }
            catch (Exception e)
            {

                respuesta.Error = true;
                respuesta.Mensaje = $"ERROR" + e.Message;
            }
            return respuesta;
        }
    }
    public class RespuestaBusqueda
    {
        public string Mensaje { get; set; }
        public Liquidación liquidacion { get; set; }
        public bool Error { get; set; }
    }

    public class RespuestaConsulta
    {
        public string Mensaje { get; set; }
        public List<Liquidación> liquidaciones { get; set; }
        public bool Error { get; set; }
    }
}
