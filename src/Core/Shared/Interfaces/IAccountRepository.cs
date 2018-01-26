using ShareFlow.Domain.Entities;
using ShareFlow.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareFlow.Core.Shared.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        /// <summary>
        /// Retourn the list of account which is owned by an event
        /// </summary>
        IReadOnlyList<Account> ListFromEventId(int eventId);
    }
}
