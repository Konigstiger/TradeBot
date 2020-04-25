using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models.IOL
{
    public class TituloModel
    {
        public string simbolo { get; set; }
        
        public string descripcion { get; set; }

        // ['estados_Unidos', 'argentina']
        public string pais { get; set; }

        public string mercado { get; set; }

        // ['oPCIONES', 'cEDEARS', 'tITULOSPUBLICOS', 'aCCIONES', 'cUPONESPRIVADOS', 'fONDOSDEINVERSION', 'aDR', 'iNDICES', 'bOCON', 'bONEX', 'cERTIFICADOSPAR', 'oBLIGACIONESNEGOCIABLES', 'oBLIGACIONESPYME', 'cUPONESOBL', 'lETRAS', 'lETES', 'bONOS', 'fUTURO', 'fondoComundeInversion'],
        public string tipo { get; set; }
        
        public string plazo { get; set; }

        // ['peso_Argentino', 'dolar_Estadounidense', 'real', 'peso_Mexicano', 'peso_Chileno', 'yen', 'libra', 'euro', 'peso_Peruano', 'peso_Colombiano', 'peso_Uruguayo']
        public string moneda { get; set; }

        /*
        "simbolo": "ADCGLOA",
        "descripcion": "Adcap Renta Dólar - Clase D",
        "pais": "argentina",
        "mercado": "bcba",
        "tipo": "FondoComundeInversion",
        "plazo": "t0",
        "moneda": "dolar_Estadounidense"
        */
    }
}
