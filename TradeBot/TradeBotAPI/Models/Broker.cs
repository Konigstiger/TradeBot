using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models
{
    /// <summary>
    /// Represents an intermediary that executes buy and sell orders, among other tasks.
    /// </summary>
    public class Broker : IBroker
    {
        private string name;

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        private double commission;

        public double GetCommission()
        {
            return commission;
        }

        public void SetCommission(double value)
        {
            commission = value;
        }

        public Broker(string name= "IOL [Invertir Online]", double commission=0.005)
        {
            SetName(name);
            SetCommission(commission);
        }

    }
}
