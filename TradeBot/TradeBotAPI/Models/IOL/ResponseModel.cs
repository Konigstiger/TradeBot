using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models.IOL
{
    public class ResponseModel
    {
        public bool ok { get; set; }

        public DetalleMensaje[] messages { get; set; }

        /*
          "cantidad": 100.62,
          "comprometido": 0.0000,
          "puntosVariacion": 1.01827790,
          "variacionDiaria": 0.00,
          "ultimoPrecio": 1.01827790,
          "ppc": 1.017,
          "gananciaPorcentaje": 0.17,
          "gananciaDinero": 0.17,
          "valorizado": 102.464010031920,
          "titulo": {
            "simbolo": "ADCGLOA",
            "descripcion": "Adcap Renta Dólar - Clase D",
            "pais": "argentina",
            "mercado": "bcba",
            "tipo": "FondoComundeInversion",
            "plazo": "t0",
            "moneda": "dolar_Estadounidense"
          }
        }
        */

    }
}
