using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ShareFlow.Core.Shared.Interfaces;
using ShareFlow.Core.Specifications;
using ShareFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareFlow.Infrastructure.Data.Repositories
{
    public class ExpenseRepository : EfCoreRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Retourn the list of expense which is owned by an event
        /// </summary>
        public IReadOnlyList<Expense> ListFromEventId(int eventId)
        {
            return this.Table.Join(this.Db.Set<Participant>().Where(new EqualsParticipantEventIdSpecification(eventId).ToExpression()),
                                    expense => expense.ParentId,
                                    participant => participant.Id,
                                    (expense, participant) => expense)
                            .ToList();
        }
    }
}
