using ShareFlow.Interface.Models;
using System.Collections.Generic;

namespace ShareFlow.Interface.Process.Interfaces
{
    public interface IBalanceProcess
    {
        BalanceModel Create(int eventId);
    }
}