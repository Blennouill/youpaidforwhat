using ShareFlow.Core.Services.Interface;
using ShareFlow.Core.Shared.Interfaces;
using ShareFlow.Domain.Entities;
using System.Collections.Generic;

namespace ShareFlow.Domain.Services
{
    public class AccountService : EntityService<Account>, IAccountService
    {
        public AccountService(IAccountRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Retourn the list of account which is owned by an event
        /// </summary>
        public IReadOnlyList<Account> ListFromEventId(int eventId)
        {
            return ((IAccountRepository)_repository).ListFromEventId(eventId);
        }
    }
}