using ShareFlow.Interface.Models;
using System.Collections.Generic;

namespace ShareFlow.Interface.Process.Interfaces
{
    public interface IExpenseProcess : IResourceProcess<ExpenseModel>
    {
        ExpenseModel CreateNewExpense(ExpenseModel expenseModel, int idParticipant);

        /// <summary>
        /// Return expense's list of a specific participant
        /// </summary>
        /// <param name="urlEvent">participant's id</param>
        IReadOnlyList<ExpenseModel> List(int idParticipant);

        /// <summary>
        /// Return expense's list of an event
        /// </summary>
        IReadOnlyList<ExpenseModel> ListByEventUrl(string eventUrl);
    }
}