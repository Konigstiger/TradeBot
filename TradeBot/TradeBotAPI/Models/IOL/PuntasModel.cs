using System;

namespace TradeBotAPI.Models.IOL
{
    public class PuntasModel
    {
        /*
        cantidadCompra (number, optional),
    	precioCompra (number, optional),
	    precioVenta (number, optional),
	    cantidadVenta (number, optional)
        */
        public float cantidadCompra { get; set; }

        public float precioCompra { get; set; }

        public float precioVenta { get; set; }
        
        public float cantidadVenta { get; set; }
        
        public override string ToString()
        {
            // TODO: Do this later
            //var result = cantidadCompra.to + ": " + cantidadCompra.ToString() + "] " + titulo.descripcion;
            // Segun modificadores en las llamadas, debería devolver diferente nivel de detalle.
            //return result;
            throw new NotImplementedException();
        }

    }
}
