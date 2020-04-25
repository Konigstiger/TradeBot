using System.ComponentModel.DataAnnotations;

namespace TradeBotAPI.Models
{
    public interface IBroker
    {
        double GetCommission();
        void SetCommission(double value);

        string GetName();
        void SetName(string value);
    }
}