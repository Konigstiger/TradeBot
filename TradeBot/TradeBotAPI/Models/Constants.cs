using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models
{
    public static class Constants
    {
        public static string number_type_name = "number";
        public static string datetime_type_name = "datetimeV2.datetime";
        public static string date_type_name = "datetimeV2.date";
        public static string currency_type_name = "currency";
        public static string crlf = "\r\n";
        public static string separator = "----------------------------------";
        public static string double_separator = "-------------------------------------------------------------------------------";
        public static int max_decimals = 2;
        public static int max_variation = 10;
        public static int min_variation = -10;
        public static float tax = 0.01F;
    }
}
