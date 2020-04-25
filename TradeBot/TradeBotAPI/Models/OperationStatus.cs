using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeBotAPI.Models
{
    public enum OperationStatus
    {
        Invalid = 0,
        Pending = 1,
        InProgress = 2,
        Success = 3,
        Failure = 4,
    }
}
