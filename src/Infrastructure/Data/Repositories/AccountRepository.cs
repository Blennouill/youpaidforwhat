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
    public class AccountRepository : EfCoreRepository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Retourn the list of account which is owned by an event
        /// </summary>
        public IReadOnlyList<Account> ListFromEventId(int eventId)
        {
            return this.Table.Join(this.Db.Set<Participant>().Where(new EqualsParticipantEventIdSpecification(eventId).ToExpression()).ToList(),
                                    account => account.ParentId,
                                    participant => participant.Id,
                                    (account, participant) => account)
                            .ToList();
        }
    }
}
