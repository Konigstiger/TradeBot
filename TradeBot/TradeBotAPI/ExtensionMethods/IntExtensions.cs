using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TradeBotAPI.ExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }

        /// <summary>
        /// Tries to convert the string to int. If it can't do it, will return 0 (valid int).
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ToInt(this String input)
        {
            if (!int.TryParse(input, out int result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Tries to convert the string to float. If it can't do it, will return 0 (valid float).
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static float ToFloat(this String input)
        {
            if (!float.TryParse(input, out float result))
            {
                result = 0;
            }
            return result;
        }

    }
}
