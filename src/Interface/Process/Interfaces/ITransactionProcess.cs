using ShareFlow.Interface.Models;
using System.Collections.Generic;

namespace ShareFlow.Interface.Process.Interfaces
{
    public interface ITransactionProcess
    {
        IReadOnlyList<TransactionModel> List(string eventUrl);
        void GenerateTransactionsByEvent(int eventId);
    }
}