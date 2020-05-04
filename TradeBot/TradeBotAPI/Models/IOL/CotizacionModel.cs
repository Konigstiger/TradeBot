using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models.IOL
{
    public class CotizacionModel
    {

        public string simbolo { get; set; }

        public PuntasModel puntas { get; set; }
        
        public float ultimoPrecio { get; set; }
        
        public float variacionPorcentual { get; set; }
        
        public float apertura { get; set; }
        
        public float maximo { get; set; }
        
        public float minimo { get; set; }
        
        public float ultimoCierre { get; set; }
        
        public float volumen { get; set; }
        
        public float cantidadOperaciones { get; set; }
        
        public string fecha { get; set; }
        
        public string tipoOpcion { get; set; }
        
        public string precioEjercicio { get; set; }
        
        public string fechaVencimiento { get; set; }
        
        public string mercado { get; set; }
        
        public string moneda { get; set; }

        public CotizacionModel()
        {
            // TODO: maybe create a new custom constructor.
        }

        public override string ToString()
        {
            // TODO: Use StringBuilder
            //var result = cantidad + " [" + titulo.simbolo + "] " + titulo.descripcion;

            //return result;
            throw new NotImplementedException();
        }

        /*
        simbolo (string, optional),
        puntas (PuntasModel, optional),
        ultimoPrecio (number, optional),
        variacionPorcentual (number, optional),
        apertura (number, optional),
        maximo (number, optional),
        minimo (number, optional),
        ultimoCierre (number, optional),
        volumen (number, optional),
        cantidadOperaciones (number, optional),
        fecha (string, optional),
        tipoOpcion (string, optional),
        precioEjercicio (number, optional),
        fechaVencimiento (string, optional),
        mercado (string, optional),
        moneda (string, optional) 
        */

    }
}
