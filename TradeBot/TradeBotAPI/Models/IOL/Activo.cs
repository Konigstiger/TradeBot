using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models.IOL
{
    public class Activo
    {
        public float cantidad { get; set; }
        public float comprometido { get; set; }
        public float puntosVariacion { get; set; }
        public float variacionDiaria { get; set; }
        public float ultimoPrecio { get; set; }
        public float ppc { get; set; }
        public float gananciaPorcentaje { get; set; }
        public float gananciaDinero { get; set; }
        public float valorizado { get; set; }
        
        public TituloModel titulo { get; set; }

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
