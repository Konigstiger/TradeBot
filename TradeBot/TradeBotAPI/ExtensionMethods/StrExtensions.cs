using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TradeBotAPI.ExtensionMethods
{
    public static class StrExtensions
    {
        public static int Occurrence(this String instr, string search)
        {
            return Regex.Matches(instr, search).Count;
        }


    }
}
