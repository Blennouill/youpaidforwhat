using ShareFlow.Core.Services.Interface;
using ShareFlow.Core.Shared.Interfaces;
using ShareFlow.Domain.Entities;
using System.Collections.Generic;

namespace ShareFlow.Domain.Services
{
    public class ExpenseService : EntityService<Expense>, IExpenseService
    {
        public ExpenseService(IExpenseRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Retourn the list of expenses which is owned by an event
        /// </summary>
        public IReadOnlyList<Expense> ListFromEventId(int eventId)
        {
            return ((IExpenseRepository)_repository).ListFromEventId(eventId);
        }
    }
}