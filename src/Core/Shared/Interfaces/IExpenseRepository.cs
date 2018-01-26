using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Core.Shared.Interfaces
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        /// <summary>
        /// Retourn the list of expense which is owned by an event
        /// </summary>
        IReadOnlyList<Expense> ListFromEventId(int eventId);
    }
}
