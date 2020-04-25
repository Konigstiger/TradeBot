using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models.IOL
{
    public class VenderBindingModel
    {
        //['bCBA', 'nYSE', 'nASDAQ', 'aMEX', 'bCS', 'rOFX']
        public string mercado { get; set; }
        
        public string simbolo { get; set; }
        
        public int cantidad { get; set; }
        
        public float precio { get; set; }
        
        // NOTE: this property can only have values like t0, t1, t2
        public string plazo { get; set; }

        public string validez { get; set; }

        /*
        ComprarBindingModel {
            mercado (string): = ['bCBA', 'nYSE', 'nASDAQ', 'aMEX', 'bCS', 'rOFX'],
            simbolo (string): ,
            cantidad (number): ,
            precio (number): ,
            plazo (string): = ['t0', 't1', 't2'],
            validez (string):
        }         
        */

        /*
         VenderBindingModel {
            mercado (string): = ['bCBA', 'nYSE', 'nASDAQ', 'aMEX', 'bCS', 'rOFX'],
            simbolo (string): ,
            cantidad (number): ,
            precio (number): ,
            validez (string): ,
            plazo (string, optional) = ['t0', 't1', 't2']
         }
         */
    }
}
